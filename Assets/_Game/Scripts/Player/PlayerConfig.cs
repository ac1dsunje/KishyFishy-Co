using UnityEngine;

namespace _Game.Scripts.Player
{
[CreateAssetMenu(fileName = "NewPlayerConfig", menuName = "Configs/Player/Config")]
public class PlayerConfig: ScriptableObject
{
    [field: SerializeField] public float MoveSpeed { get; private set; } = 5f;
    [field: SerializeField] public float JumpSpeed { get; private set; } = 5f;
    [field: SerializeField] public float SprintK { get; private set; } = 2f;
    [field: SerializeField] public float SitK { get; private set; } = .5f;
}
}