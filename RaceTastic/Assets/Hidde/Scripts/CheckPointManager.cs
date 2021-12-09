using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public int laps;

    public static CheckPointManager instance;

    public TrialTimer timer;

    private int checkPointsLeft;

    private List<CheckPoint> checkPoints = new List<CheckPoint>();

    private int lapsDone;

    private void Awake()
    {
        instance = this;
    }

    public void AddCheckPoint(CheckPoint point)
    {
        checkPoints.Add(point);
    }

    public void TriggerCheckPoint()
    {
        checkPointsLeft++;
        if (checkPointsLeft == checkPoints.Count)
        {
            StartCoroutine(ResetRounds());
            lapsDone++;

            if (lapsDone == laps)
            {
                OnFinish();
            }
        }
    }

    private void OnFinish()
    {
        print("Race finished!");

        int sec = (int)Mathf.Round(timer.seconds);
        int min = (int)Mathf.Round(timer.minutes);

        ScoreTracker st = FindObjectOfType<ScoreTracker>();
        if(st != null)
        {
            st.SetScore(sec, min);
        }
    }

    private IEnumerator ResetRounds()
    {
        yield return new WaitForSeconds(.5f);

        foreach (var item in checkPoints)
        {
            item.SetTriggeredState(false);
        }

        checkPointsLeft = 0;
    }
}
