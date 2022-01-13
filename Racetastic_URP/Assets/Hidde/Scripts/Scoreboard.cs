using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scoreboard
{
    public string playerName;
    public int seconds, minutes;

    public Scoreboard(string playerName, int seconds, int minutes)
    {
        this.playerName = playerName;
        this.seconds = seconds;
        this.minutes = minutes;
    }
}
