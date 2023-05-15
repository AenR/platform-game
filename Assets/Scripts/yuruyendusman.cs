using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yuruyendusman : MonoBehaviour
{
    public float hiz, deger;
    public Transform varilacakyer01, varilacakyer02;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(deger * hiz * Time.deltaTime, 0, 0)); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "varilacak")
        {
            deger *= -1;
            gameObject.transform.localScale = new Vector3(1 * deger, 1, 1);
        }
    }


}

