using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public HealthBar healthBar;
    [SerializeField] private float maxHealth;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetSliderMax(maxHealth);

    }

    void Update()
    {
        if (healthBar.Death(currentHealth))
        {
            BossDefeated();
        }
    }

    public void DamageTaken(float damage)
    {
        currentHealth -= damage;
        healthBar.SetSlider(currentHealth);
    }

    public void BossDefeated()
    {
        Time.timeScale = 0;
    }
}
