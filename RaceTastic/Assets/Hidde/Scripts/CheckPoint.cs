using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Color triggeredColor;
    private Color defaultColor;

    private bool isTriggered;

    private void Start()
    {
        // Tell the checkpointmanager to add this checkpoint to the list
        CheckPointManager.instance.AddCheckPoint(this);
        defaultColor = GetComponent<Renderer>().material.color;
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
                CheckPointManager.instance.TriggerCheckPoint();

                other.GetComponentInParent<CarRespawn>().SetRespawnPoint(transform);

                isTriggered = true;
            }
        }
    }

    public void SetTriggeredState(bool state)
    {
        isTriggered = state;
    }
}
