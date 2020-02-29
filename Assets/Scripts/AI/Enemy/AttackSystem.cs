using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    private Animator animator;
    public float minWaitTime;
    public float maxWaitTime;
    public bool fighting { get; set; }

    private float recordTime;
    private float waitTime;
    private int randAttack;
    


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (fighting) animator.SetBool("InFight", true);
        else animator.SetBool("InFight", false);
    }

    public void RandomAttack(int damages)
    {
        if (IsTimerElapsed())
        {
            randAttack = Random.Range(0, 2);
            if (randAttack == 0)
            {
                animator.SetTrigger("Punch");
            }
            else
            {
                animator.SetTrigger("Kick");
            }
            waitTime = Random.Range(minWaitTime, maxWaitTime);
            recordTime = Time.time;
        }
    }

    public bool IsTimerElapsed()
    {
        if (Time.time - recordTime >= waitTime)
        {
            return true;
        }
        return false;
    }
}
