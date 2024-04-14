using UnityEngine.UI;
using UnityEngine;

public class TrapHealthbar : MonoBehaviour
{
    public Slider slider;

    public void SetHealthbar(float currentHealth, float maxHealth)
    {
        slider.value = currentHealth / maxHealth;
    }
}
