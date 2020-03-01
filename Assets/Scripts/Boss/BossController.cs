using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int maxLife = 25;
    public float rotSpeed = 0.05f;
    public Vector3 centerExplosions;
    public Vector3 sizeExplosions;
    public GameObject explosion;

    private GameObject player;
    private int lifePoints;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        lifePoints = maxLife;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnExplosions());
    }

    // Update is called once per frame
    void Update()
    {
        //if (lifePoints <= 0)
        //{
        //    isDead = true;
        //}

        //Vector3 targetPostition = new Vector3(player.transform.position.x,
        //    transform.position.y,
        //    player.transform.position.z);

        //var targetRotation = Quaternion.LookRotation(targetPostition - transform.position);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.03f);
    }

    public void TakeDamage(int damages)
    {
        lifePoints -= damages;
    }

    private Vector3 RandomPointInBox(Vector3 center, Vector3 size)
    {

        return center + new Vector3(
            (Random.value - 0.5f) * size.x,
            (Random.value - 0.5f) * size.y,
            (Random.value - 0.5f) * size.z
        );
    }

    IEnumerator SpawnExplosions()
    {
        while (true)
        {
            float time = Random.Range(0.5f, 2.0f);
            yield return new WaitForSeconds(time);
            Vector3 pos = RandomPointInBox(centerExplosions, sizeExplosions);
            Instantiate(explosion, pos, Quaternion.identity);
        }
    }
}
