using _Game.Scripts.InputManager;
using UnityEngine;

namespace _Game.Scripts.Camera
{
[RequireComponent(typeof(CameraController))]
public class CameraController: MonoBehaviour
{
    private CameraController _cam;
    private InputHandler _input;
    private float _yaw = 0f;
    private float _pitch = 0f;
    
    private void Awake() => _cam = GetComponent<CameraController>();

    public void Construct(InputHandler input)
    {
        _input = input;
        _input.OnYaw += UpdateYaw;
        _input.OnPitch += UpdatePitch;
    }
    
    private void UpdateYaw(float value) => _yaw = value;
    private void UpdatePitch(float value) => _pitch = value;

    private void Update() => Move();

    private void Move()
    {
        _pitch = Mathf.Clamp(_pitch, -80f, 80f);

        transform.eulerAngles = new Vector3(_pitch, _yaw, 0f);
    }

    private void OnDestroy()
    {
        _input.OnYaw -= UpdateYaw;
        _input.OnPitch -= UpdatePitch;
    }
}
}