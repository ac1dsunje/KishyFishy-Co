using UnityEngine;

namespace _Game.Scripts.Player.Movement
{
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MovementConfig _config;
    private Rigidbody _rb;

    // GroundCheck
    [SerializeField] private CapsuleCollider _collider;
    [SerializeField] private float _rayOffset = 0.05f;
    [SerializeField] private LayerMask _groundMask;
    private bool _isGrounded;
    
    // Jumping
    private bool _jumpRequested;
    private const float GlobalGravity = 9.81f;
    
    // Moving
    private float _horizontalVelocity;
    private float _verticalVelocity;
    private bool _isRunning;
    private bool _isSitting;
    
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
        _horizontalVelocity = Input.GetAxisRaw("Horizontal");
        _verticalVelocity = Input.GetAxisRaw("Vertical");

        CheckSprint();
        CheckSit();
        CheckJump();
    }

    private void CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpRequested = true;
        }
    }

    private void CheckSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _isRunning = !_isRunning;
        }
    }

    private void CheckSit()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _isSitting = !_isSitting;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        Sit();
        Fall();
    }

    private void Move()
    {
        var speed = _isRunning? _config.MoveSpeed * _config.SprintK : _config.MoveSpeed;
        speed = _isSitting ? speed * _config.SitK : speed;
        _rb.linearVelocity = new Vector3(_horizontalVelocity, 0f, _verticalVelocity).normalized * speed;
    }

    private void Jump()
    {
        if (!_isGrounded) _jumpRequested = false;
        
        if (!_jumpRequested) return;
        _rb.AddForce(new Vector3(0, _config.JumpSpeed, 0), ForceMode.Impulse);
        _jumpRequested = false;
    }

    private void Fall()
    {
        if (_isGrounded) return;
        
        var gravity = Vector3.up * (-GlobalGravity * _config.GravityScale);
        _rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private void Sit()
    {
        transform.localScale = _isSitting ? new Vector3(1f, .5f, 1f) : new Vector3(1f, 1f, 1f);
    }

    private void CheckGround()
    {
        var distToGround = _collider.bounds.extents.y;
        _isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + _rayOffset, _groundMask);
    }
}
}