using System.Collections.Generic;
using _Game.Scripts.Camera;
using _Game.Scripts.Player.Movement;
using _Game.Scripts.UI;
using UnityEngine;

namespace _Game.Scripts
{
public class EntryPoint : MonoBehaviour
{
    [SerializeField] private InputHandler _input;
    [SerializeField] private CameraController _cam;
    [SerializeField] private PlayerMovement _player;
    
    [Header("UI")] 
    [SerializeField] private Overlay _overlay;
    [SerializeField] private MapUI _mapUI;
    [SerializeField] private CalendarUI _calendarUI;
    [SerializeField] private InventoryUI _inventoryUI;

    private void Awake()
    {
        _cam.Construct(_input);
        _player.Construct(_input);
    }
}
}