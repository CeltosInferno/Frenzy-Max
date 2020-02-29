using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Distance")]
public class DistanceDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetAtDistance = LookAround(controller);
        return targetAtDistance;
    }

    protected bool LookAround(StateController controller)
    {
        Transform otherTransform = GameObject.FindGameObjectWithTag("Player").transform;
        if (Vector3.Distance(otherTransform.position, controller.transform.position) <= controller.ennemyStats.lookRange)
        {
            controller.chaseTarget = otherTransform;
            return true;
        }

        return false;
    }
}
