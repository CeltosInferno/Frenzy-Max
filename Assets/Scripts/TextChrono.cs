using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChrono : MonoBehaviour
{
    private Timer timer;
    private Text textTimer;
        
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<Timer>();
        textTimer = GetComponent<Text>();
        timer.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        textTimer.text = timer.TimeString;
    }
}
