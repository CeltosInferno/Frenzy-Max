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
        EnemyAttackSystem attackSystem = controller.transform.GetComponent<EnemyAttackSystem>();

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.ennemyStats.attackRange, Color.red);

        //if (Physics.SphereCast(controller.eyes.position, controller.ennemyStats.lookSphereCastRadius,
        //        controller.eyes.forward, out hit, controller.ennemyStats.attackRange)
        //    && hit.collider.CompareTag("Player"))
        if (Physics.Raycast(controller.eyes.position,
                controller.eyes.forward, out hit, controller.ennemyStats.attackRange)
            && hit.collider.CompareTag("Player"))
        {
            attackSystem.fighting = true;
            attackSystem.MeleeRandomAttack(controller.ennemyStats.attackDamage);
        }
        else
        {
            attackSystem.fighting = false;
        }
    }
}