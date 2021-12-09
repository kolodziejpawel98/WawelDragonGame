using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireStaminaScript : MonoBehaviour
{
    private Image FireStaminaBar;
    public float CurrentFireStamina;
    private float MaxFireStamina = 100f;
    Fire Fire;

    private void Start()
    {
        FireStaminaBar = GetComponent<Image>();
        Fire = FindObjectOfType<Fire>();
    }

    private void Update()
    {
        CurrentFireStamina = Fire.FireStamina;
        FireStaminaBar.fillAmount = CurrentFireStamina / MaxFireStamina;
    }
}
