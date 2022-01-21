using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float downForce, maxBoostTime;
    public float maxSpeed, maxBrakeTorque;
    public float maxSteeringAngle;
    public Transform spawnPos;
    public Animator anims;
    public DisplaySpeed speedometer;

    private Rigidbody rb;

    private float boostTimer;

    private bool isBoosting;

    private void Awake()
    {
        Selected sl = FindObjectOfType<Selected>();
        if (sl != null)
        {
            Instantiate(sl.selectedVehicle, spawnPos.position, Quaternion.Euler(spawnPos.rotation.x, 0f, spawnPos.rotation.z), spawnPos);
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boostTimer = maxBoostTime;
    }

    public void FixedUpdate()
    {
        if (!isBoosting)
        {
            // Get the input of the player
            float motor = maxSpeed * Input.GetAxis("Vertical"); // Gets the forward input for driving and braking
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal"); // Gets the right input for steering

            anims.SetFloat("Blend", steering / maxSteeringAngle);

            if(motor >= 0)
            {
                speedometer.speedText.text = "Speed: " + (motor / 8).ToString("0") + "u/h";
            }
            else
            {
                speedometer.speedText.text = "Speed: Rev";
            }

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
                }
                else
                {
                    axleInfo.leftWheel.brakeTorque = 0;
                    axleInfo.rightWheel.brakeTorque = 0;
                }
            }
        }
        else
        {
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal"); // Gets the right input for steering
            foreach (var axleInfo in axleInfos)
            {
                // Since all vehicles are gonna be front wheel driven they are always steering and rotating
                if (axleInfo.forceWheel)
                {
                    axleInfo.leftWheel.steerAngle = steering;
                    axleInfo.rightWheel.steerAngle = steering;

                    axleInfo.leftWheel.motorTorque = maxSpeed * 2;
                    axleInfo.rightWheel.motorTorque = maxSpeed * 2;
                }
            }

            boostTimer -= Time.deltaTime;
            if(boostTimer <= 0)
            {
                isBoosting = false;
                boostTimer = maxBoostTime;
            }
        }
            
        // This is a tucked away feature to prevent the vehicle from flipping over
        rb.AddForce(-transform.up * downForce);
    }

    public void ResetForces()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        foreach (var axleInfo in axleInfos)
        {
            axleInfo.leftWheel.motorTorque = 0f;
            axleInfo.rightWheel.motorTorque = 0f;
        }
    }

    public void Boost()
    {
        isBoosting = true;
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