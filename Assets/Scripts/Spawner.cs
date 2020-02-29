using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    internal class PoolItemStruct
    {
        public GameObject Object { get; set; }
        public bool Locked { get; set; }
    }

    [SerializeField] private int poolSize = 10;
    [SerializeField] private GameObject prefab = null;
    private List<PoolItemStruct> pool;
    public float spawnTime = 10.0f;
    public float randomSpawnTimeVariation = 1.0f;

    public int PoolSize { get { return poolSize; } }

    // Start is called before the first frame update
    void Start()
    {
        pool = new List<PoolItemStruct>(poolSize);
        for (int i=0 ; i < poolSize ; i++)
        {
            var obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Add(new PoolItemStruct() { Object = obj, Locked = false });
        }
    }

    public int Available { get { return pool.FindAll(it => !it.Locked).Count; } }

    public GameObject Spawn()
    {
        if (Available <= 0) return null;

        var obj = pool.Find(it => !it.Locked);
        obj.Locked = true;
        return obj.Object;
    }

    public void Release(GameObject obj)
    {
        var objStruct = pool.Find(it => it.Object == obj);
        Debug.Assert(objStruct != null);
        objStruct.Locked = false;
        obj.SetActive(false);
    }
}
