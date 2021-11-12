using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinCar : MonoBehaviour
{
    public Vector3 spin;

    public void Update()
    {
        SpinningCar();
    }

    public void SpinningCar()
    {
        gameObject.transform.Rotate(spin.x * Time.deltaTime, spin.y * Time.deltaTime, spin.z * Time.deltaTime);
    }
}
