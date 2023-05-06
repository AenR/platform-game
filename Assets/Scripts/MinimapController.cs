using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapController : MonoBehaviour
{
    public Vector3 offset = new Vector3 (0, 0, -10);
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position = player.transform.position + offset;
    }
}
