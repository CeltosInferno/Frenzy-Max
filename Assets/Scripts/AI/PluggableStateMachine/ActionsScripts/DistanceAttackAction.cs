using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/DistanceAttack")]
public class DistanceAttackAction : Action
{
    public override void Act(StateController controller)
    {
        Attack(controller);
    }

    public void Attack(StateController controller)
    {
        RaycastHit[] hits;
        bool playerVisible = false;
        EnemyAttackSystem attackSystem = controller.transform.GetComponent<EnemyAttackSystem>();

        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.ennemyStats.attackRange, Color.red);

        hits = Physics.SphereCastAll(controller.eyes.position, controller.ennemyStats.lookSphereCastRadius,
            controller.eyes.forward, controller.ennemyStats.attackRange);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Player"))
            {
                attackSystem.fighting = true;
                attackSystem.RangedAttack(controller.ennemyStats.attackDamage);
                playerVisible = true;
            }
        }
        if (!playerVisible)
        {
            attackSystem.fighting = false;
        }
    }
}
