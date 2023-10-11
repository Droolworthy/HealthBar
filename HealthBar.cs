using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    private Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
    }

    public void AppendHealth()
    {
        _health.AddHealth();
    }

    public void DeleteHealth()
    {
        _health.RemoveHealth();
    }
}
