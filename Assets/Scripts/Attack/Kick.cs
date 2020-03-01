﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AttackSystem
{
    public class Kick : MonoBehaviour
    {
        public string inputAxisName = "Kick";
        public string[] captureTags;
        public float radius = 2.0f;
        public int dealtDamageFrenzyAmount = 1;
        public string animTriggerName = "Kick";
        public int damage = 1;

        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponentInParent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown(inputAxisName) && CheckNoCombo())
            {
                gameObject.GetComponentInParent<Frenzy>().Add(20);
                animator.SetTrigger(animTriggerName);
                Transform tr = animator.GetBoneTransform(HumanBodyBones.RightFoot);
                RaycastHit[] hits = Physics.SphereCastAll(tr.position, radius, Vector3.zero);
                EnumerableQuery<RaycastHit> query = new EnumerableQuery<RaycastHit>(hits);
                Trigger(query.Where(h => captureTags.Contains(h.collider.gameObject.tag)).ToArray());
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

        private void Trigger(params RaycastHit[] hits)
        {
            gameObject.GetComponentInParent<Frenzy>().Add(dealtDamageFrenzyAmount * hits.Length);
            foreach (RaycastHit hit in hits)
            {
                switch (hit.collider.gameObject.tag)
                {
                    case "Enemy":
                        hit.collider.gameObject.GetComponent<EnemyController>().Attack(damage);
                        break;
                }
            }
        }
    }
}
