using UnityEngine;
using UnityEngine.UI;

public class СolorСhange : MonoBehaviour
{
    [SerializeField] private Image _button;
    [SerializeField] private Color _color;

    public void RunColorChange()
    {
        _button.color = _color;
    }
}
