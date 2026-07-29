using UnityEngine;

namespace _Game.Scripts.Player
{
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;

    private Rigidbody _rb;

    private float _horizontalVelocity;
    private float _verticalVelocity;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        _horizontalVelocity = Input.GetAxis("Horizontal");
        _verticalVelocity = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = new Vector3(_horizontalVelocity, 0f, _verticalVelocity).normalized * _config.MoveSpeed;
    }
}
}
