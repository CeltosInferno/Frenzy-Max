using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
    public override void Act(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        controller.navMeshAgent.destination = controller.chaseTarget.position;
        controller.navMeshAgent.isStopped = false;
        if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance)
        {
            Vector3 targetPostition = new Vector3(controller.chaseTarget.position.x,
                controller.transform.position.y,
                controller.chaseTarget.position.z);
            controller.transform.LookAt(targetPostition);
        }
    }
}
