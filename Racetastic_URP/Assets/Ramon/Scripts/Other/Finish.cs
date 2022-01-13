using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{
    public int finishIndex;

    public GameObject hud;

    public TextMeshProUGUI time, hudTime;

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinishRace()
    {
        SceneManager.LoadScene(finishIndex);
    }

    public void Activate()
    {
        hud.SetActive(false);
        time.text = hudTime.text;
    }
}
