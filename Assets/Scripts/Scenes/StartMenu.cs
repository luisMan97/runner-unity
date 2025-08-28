using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneConstants.play);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Tutorial()
    {
        SceneManager.LoadScene(SceneConstants.tutorial);
    }
    public void Menu()
    {
        SceneManager.LoadScene(SceneConstants.menu);
    }
}
