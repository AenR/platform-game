using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Tutorial");
        //player pref sifirlanacak
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("SavedScene")); //son oynanan kayitli scene'i loadliyor
    }

}
