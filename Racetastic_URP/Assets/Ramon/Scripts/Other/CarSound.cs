using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CarSound : MonoBehaviour
{
    public float ver, pitch, volume, defaultPitch, defaultVolume;
    public AudioSource car;

    private void Update()
    {
        ver = Input.GetAxis("Vertical");

        if (ver >= 0)
        {
            car.volume = volume;
            car.pitch = pitch;
        }
        else
        {
            car.volume = defaultVolume;
            car.pitch = defaultPitch;
        }
    }
}
