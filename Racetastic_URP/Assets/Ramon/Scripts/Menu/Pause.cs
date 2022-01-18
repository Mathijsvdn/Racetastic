using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject canvasHUD, canvasPause;

    public void Update()
    {
        if (Input.GetAxis("Cancel") != 0)
        {
            canvasHUD.SetActive(false);
            canvasPause.SetActive(true);
        }
    }

    public void QuitButton(int index)
    {
        GetComponent<LoadNewScene>().StartCoroutine("LoadLevel", index);
    }
}
