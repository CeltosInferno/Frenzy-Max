using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/MeleeDecision")]
public class MeleeDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetAtDistance = LookAround(controller);
        return targetAtDistance;
    }

    protected bool LookAround(StateController controller)
    {
        if (controller.currentEnemyType == StateController.EnemyType.melee)
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
