using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI deathText;

    private int maxHealth = 20;
    private int _currentHealth;

    [SerializeField] private float deathAnimTime;
    [SerializeField] private AnimationCurve deathAnimCurve;

    private int CurrentHealth { 
        get => _currentHealth;
        set
        {
            _currentHealth = value;
            healthBar.fillAmount = (float)_currentHealth / maxHealth;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DeathScreenTimer()
    {
        float curTime = 0;
        Color currentColor = deathText.color;
        float startA = currentColor.a;
        float endA = 1;

        while (curTime < deathAnimTime)
        {
            curTime += Time.deltaTime;
            float percent = curTime / deathAnimTime;
            deathAnimCurve.Evaluate(percent);
            deathText.color = currentColor;

            yield return null;
        }
    }
}
