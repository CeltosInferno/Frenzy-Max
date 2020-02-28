using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentGameObject : MonoBehaviour
{
    public string objectTag;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag(objectTag).Length > 1)
        {
            Kill();
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
