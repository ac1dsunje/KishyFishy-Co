using UnityEngine;

namespace _Game.Scripts.UI
{
[RequireComponent(typeof(CanvasGroup))]
public abstract class ScreenManager: MonoBehaviour
{
    public bool IsOpened => Mathf.Approximately(_screen.alpha, 1);
    
    private CanvasGroup _screen;

    protected virtual void Awake()
    {
        _screen = GetComponent<CanvasGroup>();
    }

    public virtual void Toggle()
    {
        if (IsOpened)
            Hide();
        else
            Show();
    }

    public virtual void Show()
    {
        _screen.alpha = 1;
        _screen.blocksRaycasts = true;
        _screen.interactable = true;
    }

    public virtual void Hide()
    {
        _screen.alpha = 0;
        _screen.blocksRaycasts = false;
        _screen.interactable = false;
    }
}
}