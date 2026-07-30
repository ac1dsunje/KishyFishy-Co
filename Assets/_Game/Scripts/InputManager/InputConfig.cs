using UnityEngine;

namespace _Game.Scripts.InputManager
{
[CreateAssetMenu(fileName = "NewInputConfig", menuName = "Configs/Input")]
public class InputConfig: ScriptableObject
{
    [field: SerializeField] public float YSpeed { get; private set; } = 90f;
    [field: SerializeField] public float XSpeed { get; private set; } = 90f;
    [field: SerializeField] public KeyCode Jump { get; private set; } = KeyCode.Space;
    [field: SerializeField] public KeyCode Sprint { get; private set; } = KeyCode.LeftShift;
    [field: SerializeField] public KeyCode Sit { get; private set; } = KeyCode.C;
    [field: SerializeField] public KeyCode Map { get; private set; } = KeyCode.M;
    [field: SerializeField] public KeyCode Inventory { get; private set; } = KeyCode.Tab;
    [field: SerializeField] public KeyCode Calendar { get; private set; } = KeyCode.Q;
}
}