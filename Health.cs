using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private Coroutine _coroutine;
    private int _health = 10;

    public void IncreaseWellness()
    {
        float targetValue = _healthBar.value + _health;

        _coroutine = StartCoroutine(ChangeHealthBar(targetValue));
    }

    public void ReduceWellness()
    {
        float targetValue = _healthBar.value - _health;

        _coroutine = StartCoroutine(ChangeHealthBar(targetValue));
    }

    private IEnumerator TransformWellnessLevel(float targetValue)
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

        yield return StartCoroutine(TransformWellnessLevel(targetValue));

        if (_healthBar.value == targetValue)
            StopCoroutine(_coroutine);
    }
}
