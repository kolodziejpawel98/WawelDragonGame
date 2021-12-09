using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip getObwarzanekSound, fireFlameSound, runSound;
    public static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        getObwarzanekSound = Resources.Load<AudioClip>("obwarzanekEatSound");
        fireFlameSound = Resources.Load<AudioClip>("fireFlame");
        runSound = Resources.Load<AudioClip>("runSound");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "obwarzanekEatSound":
                audioSrc.PlayOneShot(getObwarzanekSound);

                break;
            case "fireFlame":
                audioSrc.PlayOneShot(fireFlameSound);
                break;
            case "runSound":
                audioSrc.PlayOneShot(runSound);
                break;
        }
    }
}
