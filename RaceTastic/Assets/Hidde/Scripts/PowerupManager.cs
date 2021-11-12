using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public void OnPowerUp(PowerUpType type)
    {
        if(type == PowerUpType.SpeedBoost)
        {
            GetComponent<CarController>().Boost();
        }
    }
}
