using System;
using UnityEngine;

namespace _Game.Scripts.InputManager
{
public class InputHandler: MonoBehaviour
{
    [SerializeField] private InputConfig _config;
    
    public event Action<float> OnHorizontal;
    public event Action<float> OnVertical;

    public event Action<float> OnYaw;
    public event Action<float> OnPitch;

    public event Action OnSprint;
    public event Action OnSit;
    public event Action OnJump;

    public event Action OnInventory;
    public event Action OnMap;
    public event Action OnCalendar;

    private float _yaw;
    private float _pitch;
    
    private void Update()
    {
        OnHorizontal?.Invoke(Input.GetAxisRaw("Horizontal"));
        OnVertical?.Invoke(Input.GetAxisRaw("Vertical"));
        
        if (Input.GetKeyDown(_config.Jump)) OnJump?.Invoke();

        if (Input.GetKeyDown(_config.Sit)) OnSit?.Invoke();
        
        if (Input.GetKeyDown(_config.Sprint)) OnSprint?.Invoke();

        if (Input.GetKeyDown(_config.Map)) OnMap?.Invoke();

        if (Input.GetKeyDown(_config.Inventory)) OnInventory?.Invoke();

        if (Input.GetKeyDown(_config.Calendar)) OnCalendar?.Invoke();
        
        _yaw += Input.GetAxis("Mouse X") * _config.YSpeed * Time.deltaTime;
        OnYaw?.Invoke(_yaw);
        _pitch -= Input.GetAxis("Mouse Y") * _config.XSpeed * Time.deltaTime;
        OnPitch?.Invoke(_pitch);
    }
}
}