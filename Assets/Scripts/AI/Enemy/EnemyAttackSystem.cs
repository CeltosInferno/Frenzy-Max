using System.Collections;
using System.Collections.Generic;
using Projectiles;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour
{
    public float minWaitTime;
    public float maxWaitTime;
    public bool fighting { get; set; }
    public Projectile projectile;
    public Transform projectileSpawn;

    private Animator animator;
    private float recordTime;
    private float waitTime;
    private int randAttack;
    private Frenzy frenzy;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        frenzy = GameObject.FindGameObjectWithTag("Player").GetComponent<Frenzy>();
    }

    void Update()
    {
        if (fighting) animator.SetBool("InFight", true);
        else animator.SetBool("InFight", false);
    }

    public void MeleeRandomAttack(int damages)
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

            frenzy.AddFromDamage(damages);

            waitTime = Random.Range(minWaitTime, maxWaitTime);
            recordTime = Time.time;
        }
    }
    public void RangedAttack(int damages)
    {
        if (IsTimerElapsed())
        {
            Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
            projectile.direction = transform.forward;
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
