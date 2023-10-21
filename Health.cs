using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
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
        Changed?.Invoke(_health);
    }

    private void Damage()
    {
        Changed?.Invoke(-_health);
    }
}
