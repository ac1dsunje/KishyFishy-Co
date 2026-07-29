using System;
using UnityEngine;

namespace _Game.Scripts
{
public class InputHandler: MonoBehaviour
{
    [SerializeField] private float _ySpeed = 90f;
    [SerializeField] private float _xSpeed = 90f;
    
    public event Action<float> OnHorizontal;
    public event Action<float> OnVertical;

    public event Action<float> OnYaw;
    public event Action<float> OnPitch;

    public event Action OnSprint;
    public event Action OnSit;
    public event Action OnJump;

    private float _yaw;
    private float _pitch;
    
    private void Update()
    {
        OnHorizontal?.Invoke(Input.GetAxisRaw("Horizontal"));
        OnVertical?.Invoke(Input.GetAxisRaw("Vertical"));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            OnSit?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            OnSprint?.Invoke();
        }
        
        _yaw += Input.GetAxis("Mouse X") * _ySpeed * Time.deltaTime;
        OnYaw?.Invoke(_yaw);
        _pitch -= Input.GetAxis("Mouse Y") * _xSpeed * Time.deltaTime;
        OnPitch?.Invoke(_pitch);
    }
}
}