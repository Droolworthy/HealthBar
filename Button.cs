using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField] private Image _buttonAddHealth;
    [SerializeField] private Image _buttonRemoveHealth;
    [SerializeField] private Health _health;

    public void AddHealth()
    {
        _health.IncreaseWellness();
    }

    public void RemoveHealth()
    {
        _health.ReduceWellness();
    }
}
