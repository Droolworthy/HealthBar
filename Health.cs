using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Image _buttonAddHealth;
    [SerializeField] private Image _buttonRemoveHealth;
    [SerializeField] private HealthBar _healthBand;

    private int _health = 10;
    private Coroutine _coroutine;

    public Coroutine Сoroutine => _coroutine;
    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_healthBar.value);
    }

    public void AddHealth()
    {
        IncreaseWellness();
    }

    public void RemoveHealth()
    {
        ReduceWellness();
    }

    public IEnumerator TransformWellnessLevel(float targetValue)
    {
        bool isWork = true;

        while (isWork)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, targetValue, Time.deltaTime * _health);

            if (_healthBar.value == targetValue)
                isWork = false;

            yield return null;
        }
    }

    private void IncreaseWellness()
    {
        float targetValue = _healthBar.value + _health;

        _coroutine = StartCoroutine(_healthBand.ChangeHealthBar(targetValue));
    }

    private void ReduceWellness()
    {
        float targetValue = _healthBar.value - _health;

        _coroutine = StartCoroutine(_healthBand.ChangeHealthBar(targetValue));
    }  
}
