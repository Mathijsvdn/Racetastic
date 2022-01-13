using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSFX : MonoBehaviour
{
    public void OnTriggerCheckpoint()
    {
        GetComponent<Animator>().SetBool("CheckpointHit", true);
        GetComponent<AudioSource>().Play();
    }

    public void OnResetCheckpoint()
    {
        GetComponent<Animator>().SetBool("CheckpointHit", false);
    }
}
