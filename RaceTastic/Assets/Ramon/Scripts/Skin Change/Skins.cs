using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skins : MonoBehaviour
{
    public bool hasBeenPurchased;
    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}
