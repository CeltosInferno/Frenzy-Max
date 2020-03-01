using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class StateController : MonoBehaviour
{
    public EnemyType currentEnemyType;
    public EnnemyStats ennemyStats;
    public State currentState;

    public Transform eyes;
    public List<Transform> wayPointList;
    public State remainState;

    [HideInInspector] public enum EnemyType { ranged, melee};
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public ThirdPersonCharacter thirdPersonCharacter;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updatePosition = false;
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
