using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Button _buttonAddHealth;
    [SerializeField] private Button _buttonRemoveHealth;

    private Coroutine _coroutine;
    private int _health = 10;

    public void AddHealth()
    {
        float targetValue = _healthBar.value + _health;

        _coroutine = StartCoroutine(ChangeHealthBar(targetValue));
    }

    public void RemoveHealth()
    {
        float targetValue = _healthBar.value - _health;

        _coroutine = StartCoroutine(ChangeHealthBar(targetValue));
    }

    private IEnumerator TransformHealthLevel(float targetValue)
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

    private IEnumerator ChangeHealthBar(float targetValue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        yield return StartCoroutine(TransformHealthLevel(targetValue));

        if (_healthBar.value == targetValue)
            StopCoroutine(_coroutine);
    }
}
