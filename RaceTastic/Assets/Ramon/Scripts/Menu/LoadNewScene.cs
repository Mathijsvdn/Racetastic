using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadNewScene : MonoBehaviour
{
    public float transitionTime;

    public IEnumerator LoadLevel(int index)
    {
        yield return new WaitForSeconds(transitionTime);
        Debug.Log("Scene Loaded");
        SceneManager.LoadScene(index);
    }
}