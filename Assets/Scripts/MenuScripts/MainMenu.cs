using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int lastLevel = 1;
    public void Exit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Settings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Play()
    {
        SceneManager.LoadScene("PlayMenu");
    }
}
