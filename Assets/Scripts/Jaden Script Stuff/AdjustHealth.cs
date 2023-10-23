using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustHealth : MonoBehaviour
{
    public Health health;
    public Image fillImage;
    private Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
        if (slider == null)
        {
            Debug.LogError("Slider component not found on this GameObject.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (slider != null && health != null)
        {
            if (slider.value <= slider.minValue)
            {
                fillImage.enabled = false;
            }
            if (slider.value > slider.minValue && !fillImage.enabled)
            {
                fillImage.enabled = true;
            }

            float fillValue = health.currentHealth / health.maxHealth;
            slider.value = fillValue;
        }
    }

    public void ApplyDamage(float damageAmount)
    {
        if (health != null)
        {
            health.TakeDamage(damageAmount);
        }
    }
}
