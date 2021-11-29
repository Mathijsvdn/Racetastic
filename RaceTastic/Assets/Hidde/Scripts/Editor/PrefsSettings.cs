using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class PrefsSettings : MonoBehaviour
{
    [MenuItem("Preferance/Clear")]
    static void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
}
