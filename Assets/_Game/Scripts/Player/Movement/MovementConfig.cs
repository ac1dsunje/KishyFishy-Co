using UnityEngine;

namespace _Game.Scripts.Player
{
[CreateAssetMenu(fileName = "NewMovementConfig", menuName = "Configs/Player/Movement")]
public class MovementConfig: ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
    [field: SerializeField] public float JumpSpeed { get; private set; } = 5f;
    [field: SerializeField] public float SprintK { get; private set; } = 2f;
    [field: SerializeField] public float SitK { get; private set; } = .5f;
    
    [field: SerializeField] public float GravityScale { get; private set; } = 1f;
}
}