using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Health _health;

    private Coroutine _coroutine;

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
        _coroutine = StartCoroutine(ChangeWellnessBand(health));
    }

    private IEnumerator ChangeWellnessBand(float targetValue) 
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        yield return StartCoroutine(TransformWellnessLevel(targetValue));

        if (_healthBar.value == targetValue)
            StopCoroutine(_coroutine);
    }

    private IEnumerator TransformWellnessLevel(float targetValue)
    {
        bool isWork = true;

        int health = 10;

        while (isWork)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, targetValue, Time.deltaTime * health);

            if (_healthBar.value == targetValue)
                isWork = false;

            yield return null;
        }
    }
}
