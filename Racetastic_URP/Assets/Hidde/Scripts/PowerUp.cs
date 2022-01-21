using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float rotationSpeed;
    public PowerUpType type;

    public Vector3 rotation;

    public Renderer render;

    public GameObject powerupEffect;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {
        transform.Rotate(rotation * Time.deltaTime);
        OnUpdate();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(powerupEffect != null)
        {
            //TODO PowerupDingen
            GameObject effect = Instantiate(powerupEffect, transform.position, transform.rotation);
            Destroy(effect, 5f);
        }

        OnPowerUp();

        // Destroy the powerupobj
        render.enabled = false;
    }

    public void ResetVisual()
    {
        render.enabled = true;
    }

    public virtual void OnPowerUp()
    {

    }

    public virtual void OnUpdate()
    {

    }
}

public enum PowerUpType
{
    SpeedBoost,
    TrackingRocket,
    Shortcut,
    SmokeScreen
}