using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    int players;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        players = PlayerPrefs.GetInt("Players");
    }

    public void StartGame(string name)
    {
        players = PlayerPrefs.GetInt("Players");

        players++;
        PlayerPrefs.SetInt("Players", players);

        PlayerPrefs.SetString("PlayerName" + players, name);
    }

    public void SetScore(int seconds, int minutes)
    {
        PlayerPrefs.SetInt("PlayerTimeS" + players, seconds);
        PlayerPrefs.SetInt("PlayerTimeM" + players, minutes);
    }
}
