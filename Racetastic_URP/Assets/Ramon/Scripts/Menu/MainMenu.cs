using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private LoadNewScene scene;

    public GameObject menuScreen, startScreen, background;
    private bool hasPressedAnyKey;
    public bool AnyKeyEnabled;

    void Start()
    {
        scene = GetComponent<LoadNewScene>();    
    }

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

    public void SingleplayerButton(int index)
    {
        Debug.Log("Singleplayer Started!");
        scene.StartCoroutine("LoadLevel", index);
    }

    public void MultiplayerButton(int index)
    {
        Debug.Log("Multiplayer Started!");
        scene.StartCoroutine("LoadLevel", index);
    }

    public void ExitButton()
    {
        Debug.Log("Exit Game!");
        Application.Quit();
    }
}
