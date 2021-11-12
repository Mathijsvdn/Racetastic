using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float downForce;
    public float maxSpeed, maxBrakeTorque;
    public float maxSteeringAngle;

    private Rigidbody rb;

    private bool isFullyGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        // Get the input of the player
        float motor = maxSpeed * Input.GetAxis("Vertical"); // Gets the forward input for driving and braking
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal"); // Gets the right input for steering

        foreach (var axleInfo in axleInfos)
        {
            // Since all vehicles are gonna be front wheel driven they are always steering and rotating
            if (axleInfo.forceWheel)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;

                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            // If the player presses the spacebar the car wil use the handbrake
            if (Input.GetKey(KeyCode.Space))
            {
                axleInfo.leftWheel.brakeTorque = maxBrakeTorque;
                axleInfo.rightWheel.brakeTorque = maxBrakeTorque;
            }else
            {
                axleInfo.leftWheel.brakeTorque = 0;
                axleInfo.rightWheel.brakeTorque = 0;
            }
        }
            
        // This is a tucked away feature to prevent the vehicle from flipping over
        rb.AddForce(-transform.up * downForce * Time.fixedDeltaTime);
    }
}


// In this class we can assign the wheel and whether they are used to drive or not
[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool forceWheel;
}