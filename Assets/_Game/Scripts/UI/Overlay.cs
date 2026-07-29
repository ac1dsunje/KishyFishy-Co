using TMPro;
using UnityEngine;

namespace _Game.Scripts.UI
{
public class Overlay: ScreenManager
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void Awake()
    {
        base.Awake();
        Show();
        _text.text = "KishyFishyCo.";
    }
}
}