using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public GameObject smokeParticle;

    private bool hasSmoke;

    public void OnPowerUp(PowerUpType type)
    {
        if(type == PowerUpType.SpeedBoost)
        {
            GetComponent<CarController>().Boost();
        }else if(type == PowerUpType.SmokeScreen)
        {
            hasSmoke = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (hasSmoke)
            {
                hasSmoke = false;
                Instantiate(smokeParticle, transform.position, transform.rotation);
            }
        }
    }
}
