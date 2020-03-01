using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnnemyStats ennemyStats;
    public float deathTime = 5;
    public GameObject explosion;
    public State resetState;

    private int lifePoints;
    private new Rigidbody rigidbody;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private Collider collider;
    private bool alive = true;

    public AudioClip explosionSound;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        lifePoints = ennemyStats.lifePoints;
        navMeshAgent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifePoints <= 0 && alive)
        {
            Kill();
            alive = false;
        }
    }

    public void Attack(int damages)
    {
        lifePoints -= damages;
    }

    public void Knockback(Vector3 direction, float intensity)
    {
        rigidbody.AddForce(direction.normalized * intensity);
    }

    public void Kill()
    {
        rigidbody.useGravity = false;
        collider.enabled = false;
        navMeshAgent.isStopped = true;
        navMeshAgent.enabled = false;
        GetComponent<StateController>().enabled = false;
        animator.SetBool("IsDead", true);
        StartCoroutine(DisableAndReset(deathTime, explosion));
    }

    IEnumerator DisableAndReset(float time, GameObject objToInstanciate)
    {
        yield return new WaitForSeconds(time);
        SoundManager.instance.PlaySound(explosionSound);
        alive = true;
        collider.enabled = true;
        lifePoints = ennemyStats.lifePoints;
        navMeshAgent.enabled = true;
        GetComponent<StateController>().enabled = true;
        GetComponent<StateController>().currentState = resetState;
        animator.SetBool("IsDead", false);
        gameObject.SetActive(false);
        GameObject instanciated = Instantiate(objToInstanciate, transform.position, Quaternion.identity);
    }
}
