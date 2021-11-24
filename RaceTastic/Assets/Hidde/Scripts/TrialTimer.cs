using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialTimer : MonoBehaviour
{
    public float seconds;
    public float minutes;

    private void Update()
    {
        seconds += Time.deltaTime;
        PlayerUI.instance.timerText.text = minutes + ":" + seconds.ToString("0");

        if(seconds >= 59)
        {
            seconds = 1;
            minutes++;
        }

    }
}
