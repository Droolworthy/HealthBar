using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private readonly int _health = 10;

    public event UnityAction<float> Changed;

    public void AddHealth()
    {
        Heal();
    }

    public void RemoveHealth()
    {
        Damage();
    }

    private void Heal()
    {
        ChangeWellness(_health);
    }

    private void Damage()
    {
        ChangeWellness(-_health);
    }

    private void ChangeWellness(float health) 
    {
        float targetValue = _healthBar.value + health;

        Changed?.Invoke(targetValue);
    }
}
