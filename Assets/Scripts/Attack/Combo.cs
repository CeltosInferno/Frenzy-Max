using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AttackSystem
{
    public class Combo : MonoBehaviour
    {
        public string[] inputAxisSequence;
        public float timeBetweenInputs;
        public HumanBodyBones castBone;
        public float radius = 2.0f;
        public string[] captureTags;
        public string animationResetTrigger;
        public string animationSetTrigger;
        public int dealtDamageFrenzyAmount = 1;

        private int seqCursor = 0;
        private float timer = 0.0f;
        private Animator animator;

        public bool Triggered { get; private set; } = false;

        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponentInParent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (seqCursor < inputAxisSequence.Length)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenInputs)
                {
                    seqCursor = 0;
                    timer = 0.0f;
                }

                if (Input.GetButtonDown(inputAxisSequence[seqCursor]))
                {
                    seqCursor++;
                    timer = 0.0f;
                }
            }

            if (seqCursor >= inputAxisSequence.Length)
            {
                Triggered = true;
                animator.ResetTrigger(animationResetTrigger);
                animator.SetTrigger(animationSetTrigger);
                Transform tr = animator.GetBoneTransform(castBone);
                RaycastHit[] hits = Physics.SphereCastAll(tr.position, radius, Vector3.zero);
                EnumerableQuery<RaycastHit> query = new EnumerableQuery<RaycastHit>(hits);
                Trigger(query.Where(h => captureTags.Contains(h.collider.gameObject.tag)).ToArray());
                seqCursor = 0;
                StartCoroutine("Reset");
            }
        }

        private IEnumerator Reset()
        {
            yield return new WaitForEndOfFrame();
            Triggered = false;
            yield return null;
        }

        private void Trigger(params RaycastHit[] hits)
        {
            gameObject.GetComponentInParent<Frenzy>().Add(dealtDamageFrenzyAmount * hits.Length);
        }
    }
}
