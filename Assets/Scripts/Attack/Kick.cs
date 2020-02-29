using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AttackSystem
{
    public abstract class Kick : MonoBehaviour
    {
        public string inputAxisName = "Kick";
        public string[] captureTags;
        public float radius = 2.0f;

        private Animator animator;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton(inputAxisName) && CheckNoCombo())
            {
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


        protected abstract void Trigger(params RaycastHit[] hits);
    }
}
