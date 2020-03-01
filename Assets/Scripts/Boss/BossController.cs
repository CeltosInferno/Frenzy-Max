using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxLife = 25;

    private int lifePoints;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        lifePoints = maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoints <= 0)
        {
            isDead = true;
        }
    }

    public void TakeDamage(int damages)
    {
        lifePoints -= damages;
    }
}
