using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    public abstract class Punch : MonoBehaviour
    {
        public string inputAxisName = "Punch";

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(inputAxisName)) Trigger();
        }

        protected abstract void Trigger();
    }
}
