using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Frenesy : MonoBehaviour
{
    [SerializeField] private int absMaxValue = 100;
    [SerializeField] private int absSwitchValue = 10;

    public int Value { get; private set; } = 0;
    public FrenesyState FrenesyMode { get; private set; } = FrenesyState.Lower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (System.Math.Abs(Value) >= absMaxValue) Die();
        if (FrenesyMode == FrenesyState.Lower && Value >= absSwitchValue) Switch(FrenesyState.Upper);
        if (FrenesyMode == FrenesyState.Upper && Value <= -absSwitchValue) Switch(FrenesyState.Lower);
    }

    private void Die()
    {
        Debug.Log("You are dead !");
        SceneManager.LoadScene(0);
    }

    private void Switch(FrenesyState state)
    {
        FrenesyMode = state;
    }
}
