using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frenzy : MonoBehaviour
{
    internal class TransitionModel
    {
        public int Value { get; set; }
        public FrenesyState State { get; set; }
        public bool hasBeenDestroyed { get; set; } = false;
    }

    private static TransitionModel currentState = new TransitionModel() { Value = 0, State = FrenesyState.Upper };

    [SerializeField] private int absMaxValue = 100;
    [SerializeField] private int absSwitchValue = 10;
    [SerializeField] private GameObject lowerPlayerEntity = null;
    [SerializeField] private GameObject upperPlayerEntity = null;
    private Animator animator;

    public enum FrenesyState { Lower, Upper }

    public int Value { get; private set; } = 0;
    public FrenesyState FrenesyMode { get; private set; } = FrenesyState.Upper;
    public float Ratio { get { return (Value + absMaxValue) / (float)(2 * absMaxValue); } }

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (System.Math.Abs(Value) >= absMaxValue) Die();
        if (FrenesyMode == FrenesyState.Lower && Value >= absSwitchValue) Switch();
        if (FrenesyMode == FrenesyState.Upper && Value <= -absSwitchValue) Switch();
    }

    void OnDestroy()
    {
        if (currentState.hasBeenDestroyed) return;

        currentState.Value = Value;
        if (FrenesyMode == FrenesyState.Lower) currentState.State = FrenesyState.Upper;
        if (FrenesyMode == FrenesyState.Upper) currentState.State = FrenesyState.Lower;
        currentState.hasBeenDestroyed = true;
    }

    private void Init()
    {
        Value = currentState.Value;
        FrenesyMode = currentState.State;
        Switch();
        currentState.hasBeenDestroyed = false;
    }

    public void Add(int amount)
    {
        Value += amount;
    }

    public void AddFromDamage(int amount)
    {
        amount = System.Math.Abs(amount);
        if (FrenesyMode == FrenesyState.Lower) Add(-amount);
        if (FrenesyMode == FrenesyState.Upper) Add(amount);
    }

    private void Die()
    {
        Debug.Log("You are dead !");
        animator.SetBool("Death", true);
    }

    public void Reset()
    {
        Value = 0;
        FrenesyMode = FrenesyState.Lower;
        animator.SetBool("Death", false);
    }

    private void Switch()
    {
        if (FrenesyMode == FrenesyState.Lower)
        {
            lowerPlayerEntity.SetActive(false);
            upperPlayerEntity.SetActive(true);
            FrenesyMode = FrenesyState.Upper;
        }
        else
        {
            upperPlayerEntity.SetActive(false);
            lowerPlayerEntity.SetActive(true);
            FrenesyMode = FrenesyState.Lower;
        }
    }
}
