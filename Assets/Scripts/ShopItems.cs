using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItems : MonoBehaviour
{
    public GameObject burun;
    public int hasNose;

    void Start()
    {
        hasNose = PlayerPrefs.GetInt("HasNose");
        if (hasNose==1)
        {
            burun.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
