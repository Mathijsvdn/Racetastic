using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject menuScreen, startScreen;
    private bool hasPressedAnyKey;

    void Update()
    {
        HiddeInducedAnger();
    }

    public void HiddeInducedAnger()
    {
        if (Input.anyKey)
        {
            if (!hasPressedAnyKey)
            {
                hasPressedAnyKey = true;
                menuScreen.SetActive(true);
                startScreen.SetActive(false);
            }
        }
    }
}
