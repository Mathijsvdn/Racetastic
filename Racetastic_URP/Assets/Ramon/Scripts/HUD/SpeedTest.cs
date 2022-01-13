using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTest : MonoBehaviour
{
    public float speed, speedMultiplier, maxSpeed, minSpeed;
    public GameObject hudManager;

    private void Update()
    {
        ChangeSpeed();
    }

    public void ChangeSpeed()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            speed += Input.GetAxis("Vertical") * speedMultiplier * Time.deltaTime;

            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }

            if (speed <= minSpeed)
            {
                speed = minSpeed;
            }

            hudManager.GetComponent<DisplaySpeed>().UpdateSpeedText(speed);
        }
    }
}
