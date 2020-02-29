using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public class GreenPill : Item
    {
        [SerializeField] private int amount = 1;
        public int Amount { get { return amount; } set { amount = System.Math.Abs(value); } }

        private Frenzy frenzy;

        void Start()
        {
            Amount = amount;
            frenzy = GameObject.FindObjectOfType<Frenzy>();
        }

        protected override void ApplyEffect(GameObject player)
        {
            frenzy.Add(-Amount);
        }
    }
}
