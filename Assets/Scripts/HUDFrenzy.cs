using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDFrenzy : MonoBehaviour
{
    private Frenzy frenzy;
    private Image barFrenzy;

    // Start is called before the first frame update
    void Start()
    {
        frenzy = GameObject.FindGameObjectWithTag("Player").GetComponent<Frenzy>();
        barFrenzy = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        barFrenzy.fillAmount = 1 - frenzy.Ratio;
    }
}
