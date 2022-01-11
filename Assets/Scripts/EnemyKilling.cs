using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyKilling : MonoBehaviour
{
    Fire fireScript;
    public float health = 100.0f;
    public TMP_Text healthText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Fire.isVisible == true && Fire.isCollisionWithEnemy == true && Mathf.Abs(transform.position.x - Move.position.x) < 2.0f)
        {
            if (health > 0.0f)
            {
                Damage();
                UpdateHealthText();

                if(health < 2.0f)
                {
                    SoundManagerScript.PlaySound("birdDying");
                }
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
        healthText.text = string.Format("{0:N1}", health);
    }
}
