using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float rotationSpeed;
    public PowerUpType type;

    public GameObject powerupEffect;

    private void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO PowerupDingen
        GameObject effect = Instantiate(powerupEffect, transform.position, transform.rotation);
        Destroy(effect, 5f);

        other.GetComponentInParent<PowerupManager>().OnPowerUp(type);

        // Destroy the powerupobj
        Destroy(gameObject);
    }
}

public enum PowerUpType
{
    SpeedBoost,
    TrackingRocket,
    Shortcut,
    SmokeScreen
}