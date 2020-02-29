using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public abstract class Item : MonoBehaviour
    {
        public void Trigger(GameObject player)
        {
            ApplyEffect(player);
            Destroy(gameObject);
        }

        protected abstract void ApplyEffect(GameObject player);

        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                Trigger(other.gameObject);
            }
        }
    }
}
