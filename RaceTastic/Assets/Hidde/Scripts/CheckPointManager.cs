using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public int laps;

    public static CheckPointManager instance;

    private int checkPointsLeft;

    private List<CheckPoint> checkPoints = new List<CheckPoint>();

    private void Awake()
    {
        instance = this;
    }

    public void AddCheckPoint(CheckPoint point)
    {
        checkPointsLeft++;
        checkPoints.Add(point);
    }

    public void Finish()
    {
        for (int i = 0; i < checkPoints.Count; i++)
        {
            checkPoints[i].SetTriggeredState(false);
        }
    }

    public void TriggerCheckPoint()
    {
        if()
    }
}
