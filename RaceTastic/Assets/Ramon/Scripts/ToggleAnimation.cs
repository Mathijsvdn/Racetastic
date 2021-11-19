using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleAnimation : MonoBehaviour
{
    private Animator anim;
    private Vector2 exitSize;
    private float textSize;

    private void Start()
    {
        anim = GetComponent<Animator>();

        if (GetComponentInChildren<TextMeshProUGUI>() != null)
        {
            textSize = GetComponentInChildren<TextMeshProUGUI>().fontSize;
        }

        if (GetComponent<RectTransform>() != null)
        {
            exitSize = GetComponent<RectTransform>().sizeDelta;
        }
    }

    public void ToggleAnimTrue()
    {
        anim.SetBool("IsHovering", true);
    }

    public void ToggleAnimFalse()
    {
        anim.SetBool("IsHovering", false);
    }
    public void ResetTextSize()
    {
        GetComponentInChildren<TextMeshProUGUI>().fontSize = textSize;
    }

    public void ResetExitSize()
    {
        GetComponent<RectTransform>().sizeDelta = exitSize;
    }
}
