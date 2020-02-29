using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int timer;
    private bool started = false;

    public string TimeString { get { return (timer / 100.0f).ToString(); } }

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
            // Do Stuff
        }
        if (reset) ResetTimer();
    }

    public void ResetTimer(bool forceResetIfStarted = false)
    {
        if (!started || forceResetIfStarted) timer = 0;
    }
}
