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
        public string animationResetTrigger;
        public string animationSetTrigger;
        public int dealtDamageFrenzyAmount = 1;
        public int damage = 1;

        private int seqCursor = 0;
        private float timer = 0.0f;
        private Animator animator;

        public bool Triggered { get; private set; } = false;

        // Start is called before the first frame update
        void Start()
        {
            OnEnable();
        }

        void OnEnable() { 
            animator = GetComponentInParent<Animator>();
            animator.SetInteger("Dmg" + animationSetTrigger, damage);
            animator.SetInteger("Frenzy" + animationSetTrigger, dealtDamageFrenzyAmount);
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
    }
}
