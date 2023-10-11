using UnityEngine;

[RequireComponent(typeof(Display))]
public class HealthBar : MonoBehaviour
{
    private Display _display;

    private void Start()
    {
        _display = GetComponent<Display>();
    }

    public void AppendHealth()
    {
        _display.AddHealth();
    }

    public void DeleteHealth()
    {
        _display.RemoveHealth();
    }
}
