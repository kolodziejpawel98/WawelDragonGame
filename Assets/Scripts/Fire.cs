using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static float FireStamina = 100f;
    public static bool isVisible = false;
    public static bool isCollisionWithEnemy = false;

    void Update()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        isVisible = false;
        if (FireStamina > 0)
        {
            Firing();
        }

        if (Input.GetKeyUp(KeyCode.F) || FireStamina < 0)
        {
            SoundManagerScript.audioSrc.Stop();
        }
    }

    void Firing()
    {
        if (Input.GetKey(KeyCode.F))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            isVisible = true;
            if (!SoundManagerScript.audioSrc.isPlaying && FireStamina > 0)
            {
                SoundManagerScript.PlaySound("fireFlame");
            }
            FireStamina -= 0.2f;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") == true)
        {
            isCollisionWithEnemy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            isCollisionWithEnemy = false;
        }
    }
}
