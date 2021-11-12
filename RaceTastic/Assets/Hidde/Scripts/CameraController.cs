using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject forwardCam, backwardCam;

    public Transform target;
    public float speed;

    private bool lookBehind;

    private void LateUpdate()
    {
        // If the player presses the F key they can look behind them
        if (Input.GetKey(KeyCode.F))
        {
            lookBehind = true;
        }
        else
        {
            lookBehind = false;
        }

        backwardCam.SetActive(lookBehind);
        forwardCam.SetActive(!lookBehind);

        // The camera will follow the player around
        transform.position = target.position;

        // The camera will follow the player around with a smoothed delay
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * speed);
    }
}
