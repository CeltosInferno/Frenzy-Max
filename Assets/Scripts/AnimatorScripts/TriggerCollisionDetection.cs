﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TriggerCollisionDetection : StateMachineBehaviour
{
    public float radius = 2.0f;
    public string[] captureTags = new string[] { "Enemy" };
    public HumanBodyBones castBone;
    public string stateName;
    private readonly List<Collider> hasCollided = new List<Collider>(100);
    private int frenzyAmount;
    private int damage;

    private int FrenzyAmount(Animator animator) => animator.GetInteger("Frenzy" + stateName);
    private int Damage(Animator animator) => animator.GetInteger("Dmg" + stateName);

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasCollided.Clear();
        frenzyAmount = FrenzyAmount(animator);
        damage = Damage(animator);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform tr = animator.GetBoneTransform(castBone);
        Collider[] hits = Physics.OverlapSphere(tr.position, radius);
        EnumerableQuery<Collider> query = new EnumerableQuery<Collider>(hits);
        Trigger(animator, query.Where(h => captureTags.Contains(h.gameObject.tag) && !hasCollided.Contains(h)).ToArray());
    }

    private void Trigger(Animator animator, params Collider[] hits)
    {
        hasCollided.AddRange(hits);
        animator.gameObject.GetComponentInParent<Frenzy>().Add(frenzyAmount * hits.Length);
        foreach (Collider hit in hits)
        {
            switch (hit.gameObject.tag)
            {
                case "Enemy":
                    hit.gameObject.GetComponent<EnemyController>().Attack(damage);
                    break;
            }
        }
    }
}
