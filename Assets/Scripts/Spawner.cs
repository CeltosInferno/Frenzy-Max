using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int poolSize = 10;
    [SerializeField] private GameObject prefab = null;
    private List<GameObject> pool;
    public float spawnTime = 10.0f;
    public float randomSpawnTimeVariation = 1.0f;
    private float realSpawnTime;
    private float internalTime = 0.0f;

    public int PoolSize { get { return poolSize; } }

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<GameObject>(poolSize);
        for (int i=0 ; i < poolSize ; i++)
        {
            var obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(obj);
        }

        realSpawnTime = spawnTime;
    }

    void Update()
    {
        internalTime += Time.deltaTime;

        if (internalTime >= realSpawnTime)
        {
            Spawn();
            internalTime = 0.0f;
            realSpawnTime = spawnTime + Random.Range(0.0f, randomSpawnTimeVariation);
        }
    }

    public int Available { get { return pool.FindAll(it => !it.activeInHierarchy).Count; } }

    private void Spawn()
    {
        if (Available <= 0) return;

        var obj = pool.Find(it => !it.activeInHierarchy);
        obj.transform.position = gameObject.transform.position;
        obj.SetActive(true);
    }
}
