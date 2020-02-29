using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnnemyStats ennemyStats;
    
    private NavMeshAgent navMeshAgent;
    private int lifePoints;

    // Start is called before the first frame update
    void Start()
    {
        lifePoints = ennemyStats.lifePoints;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoints <= 0)
        {
            navMeshAgent.isStopped = true;
            GetComponent<StateController>().enabled = false;
        }
    }

    public void Attack(int damages)
    {
        lifePoints -= damages;
    }
}
