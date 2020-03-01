using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("TutoMobi", LoadSceneMode.Single);
    }

    public void GoToHighscore()
    {
        SceneManager.LoadScene("Highscores", LoadSceneMode.Single);
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
