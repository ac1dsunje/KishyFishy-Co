using UnityEngine;

namespace _Game.Scripts.InputManager
{
[CreateAssetMenu(fileName = "NewInputConfig", menuName = "Configs/Input")]
public class InputConfig: ScriptableObject
{
    [field: SerializeField] public KeyCode Jump { get; set; } = KeyCode.Space;
    [field: SerializeField] public KeyCode Sprint { get; set; } = KeyCode.LeftShift;
    [field: SerializeField] public KeyCode Sit { get; set; } = KeyCode.C;
    [field: SerializeField] public KeyCode Map { get; set; } = KeyCode.M;
    [field: SerializeField] public KeyCode Inventory { get; set; } = KeyCode.Tab;
    [field: SerializeField] public KeyCode Calendar { get; set; } = KeyCode.Q;
}
}