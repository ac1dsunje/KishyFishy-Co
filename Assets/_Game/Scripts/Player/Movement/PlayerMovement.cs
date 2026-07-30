using _Game.Scripts.InputManager;
using UnityEngine;

namespace _Game.Scripts.Player.Movement
{
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MovementConfig _config;
    private Rigidbody _rb;
    private InputHandler _input;

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

    private float _yaw;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Construct(InputHandler input)
    {
        _input = input;

        _input.OnHorizontal += UpdateHorizontal;
        _input.OnVertical += UpdateVertical;
        _input.OnYaw += UpdateYaw;
        _input.OnJump += RequestJump;
        _input.OnSprint += RequestSprint;
        _input.OnSit += RequestSit;
    }
    
    private void UpdateYaw(float value) => _yaw = value;
    private void UpdateHorizontal(float value) => _horizontalVelocity = value;
    private void UpdateVertical(float value) => _verticalVelocity = value;
    private void RequestJump() => _jumpRequested = true;
    private void RequestSprint() => _isRunning = !_isRunning;
    private void RequestSit() => _isSitting = !_isSitting;

    private void Update()
    {
        CheckGround();
    }

    private void FixedUpdate()
    {
        Rotate();
        Move();
        Jump();
        transform.localScale = _isSitting ? new Vector3(1f, .5f, 1f) : new Vector3(1f, 1f, 1f);
        Fall();
    }

    private void Move()
    {
        var speed = _isRunning? _config.MoveSpeed * _config.SprintK : _config.MoveSpeed;
        speed = _isSitting ? speed * _config.SitK : speed;
        var direction = Quaternion.Euler(0f, _yaw, 0f) * new Vector3(_horizontalVelocity, 0f, _verticalVelocity);
        _rb.linearVelocity = direction * speed;
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

    private void CheckGround()
    {
        var distToGround = _collider.bounds.extents.y;
        _isGrounded = Physics.Raycast(transform.position, -Vector3.up, distToGround + _rayOffset, _groundMask);
    }
    
    private void Rotate()
    {
        _rb.MoveRotation(Quaternion.Euler(0f, _yaw, 0f));
    }

    private void OnDestroy()
    {
        _input.OnHorizontal -= UpdateHorizontal;
        _input.OnVertical -= UpdateVertical;
        _input.OnYaw -= UpdateYaw;
        _input.OnJump -= RequestJump;
        _input.OnSprint -= RequestSprint;
        _input.OnSit -= RequestSit;
    }
}
}