﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Projectiles
{
    public class CalmingProjectile : Projectile
    {
        [SerializeField] private int amount = 1;
        public int Amount { get { return amount; } set { amount = System.Math.Abs(value); } }

        private Frenzy frenzy;

        void Start()
        {
            Amount = amount;
            frenzy = GameObject.FindGameObjectWithTag("Player").GetComponent<Frenzy>();
        }

        protected override void ApplyEffectOnPlayer()
        {
            frenzy.Add(-Amount);
        }
    }
}
