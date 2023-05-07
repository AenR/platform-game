using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    private int coin;
    private void Start()
    {
        coin = PlayerPrefs.GetInt("coin");
    }

    public void BuyNose()
    {
        coin = coin - 20;
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("HasNose", 1);
        Debug.Log(PlayerPrefs.GetInt("HasNose"));
    }
}
