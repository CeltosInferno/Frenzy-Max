using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLevelEnd : MonoBehaviour
{
    public string[] excludeScenes;
    private GameObject[] teleporters;

    public bool Cleared { get; private set; } = false;

    void Start()
    {
        SceneManager.sceneLoaded += OnLoad;
        OnLoad(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnLoad;
    }

    void OnLoad(Scene scene, LoadSceneMode mode)
    {
        teleporters = GameObject.FindGameObjectsWithTag("Teleporter");
        Cleared = false;

        foreach (var tp in teleporters)
        {
            tp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!excludeScenes.Contains(SceneManager.GetActiveScene().name) && !Cleared 
            && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("Level cleared");
            Cleared = true;
            foreach (var tp in teleporters)
            {
                tp.SetActive(true);
            }
        }
    }
}
