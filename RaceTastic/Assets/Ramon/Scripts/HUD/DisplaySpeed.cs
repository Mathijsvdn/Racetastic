using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplaySpeed : MonoBehaviour
{
    public TextMeshProUGUI speedText, lapText;
    private string speedTxt, lapTxt;

    private void Start()
    {
        speedTxt = speedText.text;
        lapTxt = lapText.text;

        UpdateSpeedText(0);
        UpdateLapCount(0);
    }
    public void UpdateSpeedText(float speed)
    {
        speedText.text = speedTxt + speed.ToString("f0");
    }

    public void UpdateLapCount(int lap)
    {
        lapText.text = lapTxt + lap.ToString("f0");
    }
}
