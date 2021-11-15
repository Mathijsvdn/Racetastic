using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public static PlayerUI instance;

    public TMP_Text timerText;

    private void Awake()
    {
        instance = this;
    }
}
