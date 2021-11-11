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

        transform.position = target.position;

        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * speed);
    }
}
