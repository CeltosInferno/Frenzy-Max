using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    public void Attack(StateController controller)
    {
        RaycastHit hit;

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.ennemyStats.attackRange, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.ennemyStats.lookSphereCastRadius,
                controller.eyes.forward, out hit, controller.ennemyStats.attackRange)
            && hit.collider.CompareTag("Player"))
        {
            Debug.Log("Attack !");
        }
    }
}
