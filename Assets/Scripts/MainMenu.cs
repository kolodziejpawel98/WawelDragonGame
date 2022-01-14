using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGameButton()
    {
        Move.isPlayerDead = false;
        Time.timeScale = 1;
        BulletFlight.playerHealth = 100.0f;
        Fire.FireStamina = 100.0f;
        SceneManager.LoadScene("SampleScene");
    }
}
