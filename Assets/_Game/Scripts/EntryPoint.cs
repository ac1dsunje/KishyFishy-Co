using System.Collections.Generic;
using _Game.Scripts.Camera;
using _Game.Scripts.Player.Movement;
using _Game.Scripts.UI;
using UnityEngine;

namespace _Game.Scripts
{
public class EntryPoint : MonoBehaviour
{
    [SerializeField] private float _ySpeed = 90f;
    [SerializeField] private float _xSpeed = 90f;

    [SerializeField] private Overlay _overlay;

    [SerializeField] private CameraController _cam;
    [SerializeField] private PlayerMovement _player;

    private void Awake()
    {
        _cam.Construct(_ySpeed, _xSpeed);
        _player.Construct(_ySpeed);
    }
}
}