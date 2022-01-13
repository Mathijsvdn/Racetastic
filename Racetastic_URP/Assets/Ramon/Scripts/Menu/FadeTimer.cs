using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeTimer : MonoBehaviour
{
    public GameObject fadeImage;
    public float fadeTime;
    public bool isFading;

    public void TriggerFade()
    {
        if (!isFading)
        {
            StartCoroutine("Fade");
        }
    }

    public IEnumerator Fade()
    {
        fadeImage.SetActive(true);
        isFading = true;

        yield return new WaitForSeconds(fadeTime);

        fadeImage.SetActive(false);
        isFading = false;
    }
}
