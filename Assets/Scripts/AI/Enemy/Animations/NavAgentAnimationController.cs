using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavAgentAnimationController : BaseAnimationController
{
    protected NavMeshAgent m_navMeshAgent;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        m_navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        GroundUpdate();
        MoveHandle();
        JumpHandle();
    }

    protected virtual void GroundUpdate()
    {
        animator.SetBool("OnGround", !m_navMeshAgent.isOnOffMeshLink);
    }

    protected virtual void MoveHandle()
    {
        animator.SetFloat("Forward", m_navMeshAgent.velocity.magnitude);
    }

    protected virtual void JumpHandle()
    {
        animator.ResetTrigger("Jump");
        if (m_navMeshAgent.isOnOffMeshLink)
        {
            animator.SetTrigger("Jump");
        }
    }
}
