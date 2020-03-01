using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/DistanceEnemy")]
public class DistanceDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetAtDistance = LookAround(controller);
        return targetAtDistance;
    }

    protected bool LookAround(StateController controller)
    {
        if (controller.currentEnemyType == StateController.EnemyType.ranged)
        {
            Transform otherTransform = GameObject.FindGameObjectWithTag("Player").transform;
            if (Vector3.Distance(otherTransform.position, controller.transform.position) <= controller.ennemyStats.lookRange)
            {
                controller.chaseTarget = otherTransform;
                return true;
            }
        }
        return false;
    }
}
