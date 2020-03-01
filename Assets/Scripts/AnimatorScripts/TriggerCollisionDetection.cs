using System.Collections;
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
    public int capLimit = 1;

    private int FrenzyAmount(Animator animator) => animator.GetInteger("Frenzy" + stateName);
    private int Damage(Animator animator) => animator.GetInteger("Dmg" + stateName);
    public bool CapLimited(Animator animator) => animator.gameObject.GetComponent<Frenzy>().FrenesyMode == Frenzy.FrenesyState.Lower;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        hasCollided.Clear();
        frenzyAmount = FrenzyAmount(animator);
        damage = Damage(animator);
        animator.SetBool("Fighting", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform tr = animator.GetBoneTransform(castBone);
        Collider[] hits = Physics.OverlapSphere(tr.position, radius);
        EnumerableQuery<Collider> query = new EnumerableQuery<Collider>(hits);
        IQueryable<Collider> q = 
            query.Where(h => captureTags.Contains(h.gameObject.tag) && !hasCollided.Contains(h));
        Collider[] finalHits = q.ToArray();
        if (CapLimited(animator) && q.Count() > 0)
        {
            q = q.OrderBy(h => (h.transform.position - tr.position).sqrMagnitude);
            finalHits = new Collider[] { q.First() };
        }
        Trigger(animator, finalHits);
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Fighting", false);
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
