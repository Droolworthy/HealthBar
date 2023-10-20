using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Image _buttonAddHealth;
    [SerializeField] private Image _buttonRemoveHealth;

    private readonly int _health = 10;

    public event UnityAction<float> HealthChanged;

    public void AddHealth()
    {
        IncreaseWellness();
    }

    public void RemoveHealth()
    {
        ReduceWellness();
    }

    private void IncreaseWellness()
    {
        ChangeWellness(_health);
    }

    private void ReduceWellness()
    {
        ChangeWellness(-_health);
    }

    private void ChangeWellness(float health) 
    {
        float targetValue = _healthBar.value + health;

        HealthChanged?.Invoke(targetValue);
    }
}
