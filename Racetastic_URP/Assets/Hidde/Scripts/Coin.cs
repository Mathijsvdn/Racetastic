using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : PowerUp
{
    public int earn;

    public override void OnPowerUp()
    {
        base.OnPowerUp();

        int coins = PlayerPrefs.GetInt("bits");

        coins += earn;

        PlayerPrefs.SetInt("bits", coins);
    }
}
