using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private readonly int _health = 10;

    public event UnityAction<float> Changed;

    public void Heal()
    {
        float targetValue = ChangeWellness(_health);

        Changed?.Invoke(targetValue);
    }

    public void Damage()
    {
        float targetValue = ChangeWellness(-_health);

        Changed?.Invoke(targetValue);
    }

    private float ChangeWellness(float health)
    {
        float targetValue = _healthBar.value + health;

        return targetValue;
    }
}
