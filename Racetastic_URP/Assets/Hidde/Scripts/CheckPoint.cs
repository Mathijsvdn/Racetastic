using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Color triggeredColor;
    private Color defaultColor;

    private bool isTriggered;

    private CheckPointManager mng;

   // private CheckpointSFX sfx;

    private void Start()
    {
        // Tell the checkpointmanager to add this checkpoint to the list
        mng = CheckPointManager.instance;
        defaultColor = GetComponent<Renderer>().material.color;
        //sfx = GetComponent<CheckpointSFX>();
    }

    private void Update()
    {
        if (isTriggered)
        {
            // Set the color to green
            GetComponent<Renderer>().material.color = triggeredColor;
        }
        else
        {
            // Set the color to green
            GetComponent<Renderer>().material.color = defaultColor;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            // Check if a player hits the target
            if (other.tag == "Player")
            {
                // Tell the checkpoint manager to toggle this checkpoint as triggered
                mng.TriggerCheckPoint();

                other.GetComponentInParent<CarRespawn>().SetRespawnPoint(transform);

                //sfx.OnTriggerCheckpoint();

                isTriggered = true;
            }
        }
    }
    public void SetTriggeredState(bool state)
    {
        isTriggered = state;
        //sfx.OnResetCheckpoint();
    }
}
