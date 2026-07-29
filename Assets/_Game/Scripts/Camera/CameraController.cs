using UnityEngine;

namespace _Game.Scripts.Camera
{
public class CameraController: MonoBehaviour
{
    private CameraController _cam;
    private float _yaw = 0f;
    private float _pitch = 0f;
    
    private float _xSpeed = 0f;
    private float _ySpeed = 0f;

    public void Construct(float ySpeed, float xSpeed)
    {
        _ySpeed = ySpeed;
        _xSpeed = xSpeed;
    }
    
    private void Awake()
    {
        _cam = GetComponent<CameraController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _yaw += Input.GetAxis("Mouse X") * _ySpeed * Time.deltaTime;
        _pitch -= Input.GetAxis("Mouse Y") * _xSpeed * Time.deltaTime;

        _pitch = Mathf.Clamp(_pitch, -80f, 80f);

        transform.eulerAngles = new Vector3(_pitch, _yaw, 0f);
    }
}
}