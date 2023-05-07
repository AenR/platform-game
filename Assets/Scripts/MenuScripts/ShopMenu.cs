using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    private int coin;
    private void Start()
    {
        coin = PlayerPrefs.GetInt("coin");
    }

    public void BuyNose()
    {
        if (coin >= 20)
        {
            coin = coin - 20;
            PlayerPrefs.SetInt("coin", coin);
            PlayerPrefs.SetInt("HasNose", 1);
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
