using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private readonly int _health = 10;

    public event UnityAction<float> Changed;

    public void Heal()
    {
        Changed?.Invoke(_health);
    }

    public void Damage()
    {
        Changed?.Invoke(-_health);
    }
}
