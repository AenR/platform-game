using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    int lastScene;

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Tutorial");
        PlayerPrefs.SetInt("SavedScene", 0);
        PlayerPrefs.SetInt("coin", 0);
    }

    public void LoadGame()
    {
        lastScene = PlayerPrefs.GetInt("SavedScene");
        SceneManager.LoadScene(lastScene);
    }

}
