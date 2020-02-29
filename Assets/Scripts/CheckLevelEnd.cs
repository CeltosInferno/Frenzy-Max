using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckLevelEnd : MonoBehaviour
{
    public string[] excludeScenes;

    public bool Cleared { get; private set; } = false;

    // Update is called once per frame
    void Update()
    {
        if (!excludeScenes.Contains(SceneManager.GetActiveScene().name) && !Cleared 
            && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Debug.Log("Level cleared");
            Cleared = true;
            foreach (var tp in FindObjectsOfType<Teleporter>())
            {
                tp.gameObject.SetActive(true);
            }
        }
    }
}
