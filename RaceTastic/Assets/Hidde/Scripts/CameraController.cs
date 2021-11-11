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

        Vector3 rot = transform.rotation.eulerAngles;
        Vector3 otherRot = target.rotation.eulerAngles;

        rot.y = Mathf.Lerp(rot.y, otherRot.y, Time.deltaTime * speed);

        transform.rotation = Quaternion.Euler(rot);
    }
}
