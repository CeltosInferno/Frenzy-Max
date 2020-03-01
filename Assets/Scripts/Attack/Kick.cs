using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AttackSystem
{
    public class Kick : MonoBehaviour
    {
        public string inputAxisName = "Kick";
        public int dealtDamageFrenzyAmount = 1;
        public string animTriggerName = "Kick";
        public int damage = 1;

        public AudioClip kick;

        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            OnEnable();
        }

        void OnEnable()
        {
            animator = GetComponentInParent<Animator>();
            animator.SetInteger("Dmg" + animTriggerName, damage);
            animator.SetInteger("Frenzy" + animTriggerName, dealtDamageFrenzyAmount);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown(inputAxisName) && CheckNoCombo())
            {
                animator.SetTrigger(animTriggerName);
                SoundManager.instance.PlaySound(kick);
            }
        }

        private bool CheckNoCombo()
        {
            foreach (var combo in GetComponents<Combo>())
            {
                if (combo.Triggered) return false;
            }
            return true;
        }
    }
}
