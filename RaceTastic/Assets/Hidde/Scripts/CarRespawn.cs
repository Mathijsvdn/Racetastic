using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarRespawn : MonoBehaviour
{
    public float maxRespawnTime;
    public GameObject respawnSliderObj;
    public Slider respawnSlider;

    private Transform respawnPoint;
    private float respawnTimer;

    private void Start()
    {
        respawnSliderObj.SetActive(false);

        respawnTimer = maxRespawnTime;
        respawnSlider.maxValue = maxRespawnTime;
        respawnSlider.value = maxRespawnTime;
    }

    public void SetRespawnPoint(Transform point)
    {
        respawnPoint = point;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            respawnSliderObj.SetActive(true);

            respawnTimer -= Time.deltaTime;
            respawnSlider.value = respawnTimer;

            if (respawnPoint != null && respawnTimer <= 0f)
            {
                transform.position = respawnPoint.position;
                transform.rotation = respawnPoint.rotation;
            }
        }
        else
        {
            respawnSliderObj.SetActive(false);

            respawnTimer = maxRespawnTime;
            respawnSlider.value = maxRespawnTime;
        }
    }
}
