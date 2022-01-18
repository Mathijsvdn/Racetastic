using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;
    public int offsetPos;

    private void LateUpdate()
    {
        /*
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        */

        Vector3 newPosition = player.position;
        newPosition.y += offsetPos;
        transform.position = newPosition;
        //transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y + offsetRot, 0f);
    }
}
