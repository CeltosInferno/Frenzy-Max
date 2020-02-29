using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;
    }

    private bool Look(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position,controller.eyes.forward.normalized * controller.ennemyStats.lookRange, Color.green);

        if (Physics.SphereCast(controller.eyes.position, controller.ennemyStats.lookSphereCastRadius,
                controller.eyes.forward, out hit, controller.ennemyStats.lookRange)
            && hit.collider.CompareTag("Player"))
        {
            controller.chaseTarget = hit.transform;
            return true;
        }
        return false;
    }
}
