using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToHighscore()
    {
        SceneManager.LoadScene("Highscore", LoadSceneMode.Single);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("CreditsMenu", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
