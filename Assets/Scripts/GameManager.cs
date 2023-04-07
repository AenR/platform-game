using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int coin;
    public TextMeshProUGUI para;
    public TextMeshProUGUI durum;

    void Start()
    {
        coin = PlayerPrefs.GetInt("coin");
    }


    void Update()
    {
        para.text = ("Coins: "+coin.ToString());
        PlayerPrefs.SetInt("coin", coin);
    }
}
