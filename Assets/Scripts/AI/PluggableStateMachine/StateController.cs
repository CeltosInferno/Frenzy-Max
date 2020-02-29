using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class StateController : MonoBehaviour
{
    public EnnemyStats ennemyStats;
    public State currentState;

    public Transform eyes;
    public List<Transform> wayPointList;
    public State remainState;

    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public ThirdPersonCharacter thirdPersonCharacter;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updatePosition = true;
    }

    //public void SetupAI()
    //{

    //}

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
