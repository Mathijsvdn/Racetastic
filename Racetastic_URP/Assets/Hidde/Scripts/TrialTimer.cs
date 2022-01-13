using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialTimer : MonoBehaviour
{
    public float seconds;
    public float minutes;

    private string minutesS;
    private string secondsS;

    private void Update()
    {
        seconds += Time.deltaTime;

        if (minutes < 10)
        {
            minutesS = "0" + minutes.ToString("0");
        }
        else
        {
            minutesS = minutes.ToString("0");
        }

        if(seconds < 10)
        {
            secondsS = "0" + seconds.ToString("0");
        }
        else
        {
            secondsS = seconds.ToString("0");
        }

        PlayerUI.instance.timerText.text = minutesS + ":" + secondsS;

        if(seconds >= 59)
        {
            seconds = 1;
            minutes++;
        }

    }
}
