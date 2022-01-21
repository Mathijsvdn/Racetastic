using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeSkin : MonoBehaviour
{
    public List<GameObject> skins;
    public GameObject selectVehicle;
    private GameObject storedVehicle;
    private Transform vehicleTransform;

    private int skinIndex;
    public int maxIndex, minIndex, carMaxIndex, bikeMinIndex, defaultSkinIndex;

    public List<int> skinCosts;
    public int bits;

    public TextMeshProUGUI selectText, bitsText, skinText, vehicleText;
    public string selectString, selectedString, carString, bikeString;
    public List<string> skinNames;

    public bool resetEverything;

    private void Start()
    {
        //DontDestroyOnLoad(this);

        if (resetEverything)
        {
            ResetEverything();
        }

        bits = PlayerPrefs.GetInt("bits");

        //selectedVehicle = null;
        vehicleTransform = selectVehicle.transform;
        bitsText.text = "Bits: " + bits;
        skinText.text = skinNames[skinIndex];
        CheckIfPurchased();
    }

    public void changeIndex(int index)
    {
        Debug.Log("switchingSkins");

        skinIndex += index;

        if (skinIndex > maxIndex)
        {
            skinIndex = minIndex;
        }
        else if (skinIndex < minIndex)
        {
            skinIndex = maxIndex;
        }

        CreateVehicle();
    }

    public void CreateVehicle()
    {
        if (storedVehicle != null)
        {
            Destroy(storedVehicle);
        }
        else
        {
            Destroy(selectVehicle);
        }

        selectVehicle = skins[skinIndex];
        vehicleTransform = selectVehicle.transform;
        storedVehicle = Instantiate(skins[skinIndex], vehicleTransform.position, vehicleTransform.rotation);

        CheckIfPurchased();
    }

    public void CheckIfPurchased()
    {
        if (selectVehicle.GetComponent<Skins>().hasBeenPurchased == true)
        {
            if (selectVehicle == GameObject.Find("Selected Vehicle").GetComponent<Selected>().selectedVehicle)
            {
                selectText.text = selectedString;
            }
            else
            {
                selectText.text = selectString;
            }
        }
        else
        {
            selectText.text = "Cost: " + skinCosts[skinIndex] + " Bits";
        }

        skinText.text = skinNames[skinIndex];
        if (skinIndex >= minIndex && skinIndex <= carMaxIndex)
        {
            vehicleText.text = carString;
        }
        else if (skinIndex >= bikeMinIndex && skinIndex <= maxIndex)
        {
            vehicleText.text = bikeString;
        }
    }

    public void SelectPurchase()
    {
        Debug.Log("Button Pressed!");

        if (selectVehicle.GetComponent<Skins>().hasBeenPurchased == true)
        {
            selectText.text = selectedString;
            GameObject.Find("Selected Vehicle").GetComponent<Selected>().selectedVehicle = selectVehicle;
        }
        else
        {
            ChargeBits(skinCosts[skinIndex]);
        }
    }

    public void ChargeBits(int amount)
    {
        if (amount > bits)
        {
            Debug.Log("You can't afford this!");

            return;
        }

        bits -= amount;
        bitsText.text = "Bits: " + bits;
        skins[skinIndex].GetComponent<Skins>().hasBeenPurchased = true;
        selectText.text = selectString;
    }

    public void AddBits(int amount)
    {
        bits += amount;
    }

    public void ExitButton(int index)
    {
        PlayerPrefs.SetInt("bits", bits);
        GetComponent<LoadNewScene>().StartCoroutine("LoadLevel", index);
    }

    public void BitsCheatButton(int index)
    {
        bits += index;
        bitsText.text = "Bits: " + bits;
    }

    public void ResetEverything()
    {
        //Now i don't have to change the prefabs every time i wanna test!

        PlayerPrefs.SetInt("bits", 0);

        foreach (GameObject skin in skins)
        {
            skin.GetComponent<Skins>().hasBeenPurchased = false;
        }

        GameObject.Find("Selected Vehicle").GetComponent<Selected>().selectedVehicle = skins[defaultSkinIndex];
    }
}
