using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyKilling : MonoBehaviour
{
    Fire fireScript;
    public float health = 100f;
    public TMP_Text healthText;
    
    // Start is called before the first frame update
    void Start()
    {
        fireScript = GameObject.Find("Fire").GetComponent<Fire>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fireScript.GetComponent<Renderer>().enabled == true && fireScript.isCollisionWithEnemy == true)
        {
            if(health > 0)
            {
                Damage();
                UpdateHealthText();
            }
            else
            {
                Death();
            }
        }
    }

    void Damage()
    {
        health -= 0.8f;
    }

    void Death()
    {
        Destroy(gameObject);
    }

    void UpdateHealthText()
    {
        healthText.text = string.Format("{0:N2}", health);
    }
}
