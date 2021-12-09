using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float FireStamina = 100f;
    void Update()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        if(FireStamina > 0)
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
        //Debug.Log("?>>>>>>>>>>>>>>>>> " + SoundManagerScript.audioSrc.isPlaying); idk czemu ale jak jest 0 fire staminy to jest true
        if (Input.GetKey(KeyCode.F))
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            if (!SoundManagerScript.audioSrc.isPlaying && FireStamina > 0)
            {
                SoundManagerScript.PlaySound("fireFlame");
            }
            FireStamina -= 0.2f;
        }

        

    }

}
