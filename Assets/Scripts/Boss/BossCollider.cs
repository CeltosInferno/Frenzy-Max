using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : MonoBehaviour
{
    private GameObject boss; 

    public void Attack(int damage)
    {
        boss.GetComponent<BossController>().TakeDamage(damage);
        Debug.Log("IIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
    }
}
