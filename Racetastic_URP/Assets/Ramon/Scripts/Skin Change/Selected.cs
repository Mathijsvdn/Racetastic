using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    public GameObject selectedVehicle;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
}

