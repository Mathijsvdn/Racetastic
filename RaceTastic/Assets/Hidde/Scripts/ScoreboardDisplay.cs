using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardDisplay : MonoBehaviour
{
    public List<Scoreboard> scores = new List<Scoreboard>();

    public GameObject scoreText;
    public Transform content;

    private int players;

    public List<GameObject> scoreTexts = new List<GameObject>();

    public void AddScore(string playerName, int seconds, int minutes)
    {
        scores.Add(new Scoreboard(playerName, seconds, minutes));
        UpdateText(playerName, seconds, minutes);
    }

    private void Start()
    {
        players = PlayerPrefs.GetInt("Players");

        for (int i = 0; i < players; i++)
        {
            string pName = PlayerPrefs.GetString("PlayerName" + i);
            int pTimeS = PlayerPrefs.GetInt("PlayerTimeS" + i);
            int pTimeM = PlayerPrefs.GetInt("PlayerNameM" + i);

            AddScore(pName, pTimeS, pTimeM);
        }
    }

    private void UpdateText(string playerName, int seconds, int minutes)
    {
        ClearTexts();

        GameObject text = Instantiate(scoreText, content);
        text.GetComponent<TMPro.TMP_Text>().text = "1. " + playerName + " - " + minutes + ":" + seconds;

        scoreTexts.Add(text);
    }

    private void ClearTexts()
    {
        for (int i = 0; i < scoreTexts.Count; i++)
        {
            Destroy(scoreTexts[i]);
        }

        scoreTexts.Clear();
    }
}
