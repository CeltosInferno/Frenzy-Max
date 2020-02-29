﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    public sealed class MobiPunch : Punch
    {
        public int dealtDamageFrenzyAmount = -1;

        protected override void Trigger(params RaycastHit[] hits)
        {
            gameObject.GetComponent<Frenzy>().Add(dealtDamageFrenzyAmount * hits.Length);
        }
    }
}
