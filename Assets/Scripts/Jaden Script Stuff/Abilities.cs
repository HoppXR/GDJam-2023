using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    private PlayerController playerController;

    [Header("Dash Ability")]
    public Image dashImage;
    public Text dashText;
    public KeyCode dashKey;
    public float dashCooldown = 5;

    bool isDashCooldown = false;

    private float currentDashCooldown;

    public float GetDashCooldown()
    {
        return dashCooldown;
    }
    
    void Start()
    {
        StartCoroutine(WaitForPlayerController());
    }

    IEnumerator WaitForPlayerController()
    {
        yield return null;
        playerController = GetComponent<PlayerController>();

        dashImage.fillAmount = 0;
        dashText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        DashInput();

        AbilityCooldown(ref currentDashCooldown, dashCooldown, ref isDashCooldown, dashImage, dashText);
    }

    private void DashInput()
    {
        if(Input.GetKeyDown(dashKey) && !isDashCooldown)
        {
            isDashCooldown = true;
            currentDashCooldown = dashCooldown;

            if (playerController != null)
            {
                playerController.TriggerDash();
            }
        }
    }

    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    {
        if(isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if(currentCooldown <= 0f) 
            {
                isCooldown = false;
                currentCooldown = 0f;

                if(skillImage != null) 
                {
                    skillImage.fillAmount = 0f;
                }
                if(skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if(skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if(skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }
}
