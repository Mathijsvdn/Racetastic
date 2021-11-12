using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPointManager instance;

    private int checkPointsLeft;

    private void Awake()
    {
        instance = this;
    }

    public void AddCheckPoint()
    {
        checkPointsLeft++;
    }

    public void TriggerCheckPoint()
    {
        checkPointsLeft--;
    }
}
