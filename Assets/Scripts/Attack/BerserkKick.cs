using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    public sealed class BerserkKick : Kick
    {
        protected override void Trigger(params RaycastHit[] hits)
        {
            //gameObject.GetComponent<Frenzy>().Add();
        }
    }
}
