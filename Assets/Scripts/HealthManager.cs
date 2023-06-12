using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public Image healthBar;
    public float healthAmount = 100f;
    public GameObject deadMenu;

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Time.timeScale = 0;
            deadMenu.SetActive(true);
        }
        healthText.text = healthAmount.ToString();
    }

    public void TakeDamage(float damage) //take damage function
    {
        healthAmount -= damage; // healthamount = healthamount - damage
        healthBar.fillAmount = healthAmount / 100f; // healthbar's fill amount = healthamount / 100
    }

    public void Heal (float healingAmount) //heal function
    {
        healthAmount += healingAmount; // healamount = healamount + healingamount
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }

    public void SetHealth(float health)
    {
        healthAmount = health;
        healthBar.fillAmount = healthAmount / 100f;
    }
}
