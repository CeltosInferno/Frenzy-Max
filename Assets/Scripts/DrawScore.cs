using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawScore : MonoBehaviour
{
    public Text[] fields;

    // Start is called before the first frame update
    void Start()
    {
        List<int> scores = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<HighScores>().HighScoreList;
        for (int i=0 ; i < System.Math.Min(scores.Count, fields.Length) ; i++)
        {
            fields[i].text = Timer.TimeToString(scores[i]);
        }
    }
}
