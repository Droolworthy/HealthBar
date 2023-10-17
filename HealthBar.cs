using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;

    public IEnumerator ChangeHealthBar(float targetValue)
    {
        if (_health.Сoroutine != null)
            StopCoroutine(_health.Сoroutine);

        yield return StartCoroutine(_health.TransformWellnessLevel(targetValue));

        if (_healthBar.value == targetValue)
            StopCoroutine(_health.Сoroutine);
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        _healthBar.value = health;
    }
}
