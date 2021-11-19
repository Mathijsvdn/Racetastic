using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrialTimer : MonoBehaviour
{
    public float time;

    private void Update()
    {
        time += Time.deltaTime;
        PlayerUI.instance.timerText.text = time.ToString("0");
    }
}
