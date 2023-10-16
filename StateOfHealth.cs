using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StateOfHealth : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    public event UnityAction<float> HealthChanged;

    private void Start()
    {
        HealthChanged?.Invoke(_healthBar.value);
    }
}
