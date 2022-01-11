using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image HealthBar;
    public float CurrentHealth = 0f;
    public float MaxHealth = 100f;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
    }

    private void Update()
    {
        CurrentHealth = BulletFlight.playerHealth;
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
