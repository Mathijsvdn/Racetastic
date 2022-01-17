using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseCanvas, hudCanvas;
    private LoadNewScene scene;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            hudCanvas.SetActive(false);
            pauseCanvas.SetActive(true);
            ;
        }
    }

    public void ExitButton(int index)
    {
        scene = GetComponent<LoadNewScene>();
        scene.StartCoroutine("LoadLevel", index);
    }
}
