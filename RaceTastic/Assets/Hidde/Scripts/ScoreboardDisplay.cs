using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        players = PlayerPrefs.GetInt("Players") + 1;

        for (int i = 1; i < players; i++)
        {
            string pName = PlayerPrefs.GetString("PlayerName" + i);
            int pTimeS = PlayerPrefs.GetInt("PlayerTimeS" + i);
            int pTimeM = PlayerPrefs.GetInt("PlayerNameM" + i);

            AddScore(pName, pTimeS, pTimeM);
        }
    }

    string secondsS = "";
    string minutesS = "";

    private void UpdateText(string playerName, int seconds, int minutes)
    {
        //ClearTexts();

        GameObject text = Instantiate(scoreText, content);

        if(seconds < 10)
        {
            secondsS = "0" + seconds;
        }
        else
        {
            secondsS = seconds.ToString();
        }

        if(minutes < 10)
        {
            minutesS = "0" + minutes;
        }
        else
        {
            minutesS = minutes.ToString();
        }

        text.GetComponent<TMPro.TMP_Text>().text = playerName + " - " + minutesS + ":" + secondsS;

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
