using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuScreen, startScreen, background;
    private bool hasPressedAnyKey;
    public bool AnyKeyEnabled;

    void Update()
    {
        HiddeInducedAnger();
    }

    public void HiddeInducedAnger()
    {
        if (Input.anyKey && AnyKeyEnabled)
        {
            if (!hasPressedAnyKey)
            {
                hasPressedAnyKey = true;
                background.SetActive(true);
                menuScreen.SetActive(true);
                startScreen.SetActive(false);
            }
        }
    }

    public void SingleplayerButton()
    {
        Debug.Log("Singleplayer Started!");
    }

    public void MultiplayerButton()
    {
        Debug.Log("Multiplayer Started!");
    }

    public void ExitButton()
    {
        Debug.Log("Exit Game!");
        Application.Quit();
    }
}
