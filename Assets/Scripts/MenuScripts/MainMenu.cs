using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Exit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {

    }

    public void Play()
    {

    }

}
