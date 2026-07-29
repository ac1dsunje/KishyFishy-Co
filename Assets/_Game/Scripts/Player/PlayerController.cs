using UnityEngine;

namespace _Game.Scripts.Player
{
public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerConfig _config;
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private float _rayOffset = 0.05f;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody _rb;

    private float _horizontalVelocity;
    private float _verticalVelocity;
    private bool _jumpRequested;
    
    private bool _isGrounded;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ReadInput();
        CheckGround();
    }

    private void ReadInput()
    {
        _horizontalVelocity = Input.GetAxis("Horizontal");
        _verticalVelocity = Input.GetAxis("Vertical");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        _rb.linearVelocity = new Vector3(_horizontalVelocity, 0f, _verticalVelocity).normalized * _config.MoveSpeed;
    }

    private void Jump()
    {
        if (!_isGrounded) _jumpRequested = false;
        
        if (!_jumpRequested) return;
        _rb.AddForce(new Vector3(0, _config.JumpSpeed, 0), ForceMode.Impulse);
        _jumpRequested = false;
    }

    private void CheckGround()
    {
        var distToGround = _collider.bounds.extents.y;
        _isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + _rayOffset, _groundMask);
    }
}
}
