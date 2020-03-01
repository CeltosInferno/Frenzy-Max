using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int timer;
    private bool started = false;

    public string TimeString { get { return TimeToString(timer); } }

    // Update is called once per frame
    void Update()
    {
        if (started) timer += (int) (Time.deltaTime * 1000);
    }

    public void StartTimer()
    {
        started = true;
    }

    public void EndTimer(bool reset = true, bool storeToHighScore = false)
    {
        started = false;
        if (storeToHighScore)
        {
            gameObject.GetComponent<HighScores>().AddScore(timer);
        }
        if (reset) ResetTimer();
    }

    public void ResetTimer(bool forceResetIfStarted = false)
    {
        if (!started || forceResetIfStarted) timer = 0;
    }

    public static string TimeToString(int time)
    {
        float sec = (time / 1000.0f);
        int minutes = (int) System.Math.Floor(sec) / 60;
        sec -= (minutes * 60);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.AppendFormat("{0}'{1:f3}''", minutes, sec);
        return sb.ToString();
    }
}
