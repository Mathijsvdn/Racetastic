using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public List<GameObject> carSkins, bikeSkins;
    public GameObject selectedVehicle;

    private int skinIndex;
    public int maxIndex, minIndex;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void switchSkins(int index)
    {
        Debug.Log("switchingSkins");

        skinIndex += index;

        if (skinIndex >= maxIndex)
        {
            skinIndex = minIndex;
        }
        else if (skinIndex <= minIndex)
        {
            skinIndex = maxIndex;
        }

        selectedVehicle = carSkins[skinIndex];
    }
}
