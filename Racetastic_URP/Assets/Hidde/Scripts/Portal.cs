using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform outPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Transform otherT = other.GetComponentInParent<CarController>().transform;

            otherT.position = outPoint.position;
            otherT.rotation = outPoint.rotation;
        }
    }
}
