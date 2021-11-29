using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameStartMenu : MonoBehaviour
{
    public TMPro.TMP_InputField playerName;

    public int sceneIndex;

    public void StartGame()
    {
        FindObjectOfType<ScoreTracker>().StartGame(playerName.text);

        // Load the correct scene
        SceneManager.LoadScene(sceneIndex);
    }
}
