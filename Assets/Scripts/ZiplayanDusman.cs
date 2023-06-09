using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZiplayanDusman : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float minHeight, maxHeight;
    public LayerMask lm;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector2(0, -speed);  
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesStartInColliders = false;

        RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, 8,lm);
        
        if(hit != null)
        {
            if (hit.distance <= minHeight)
            {
                rb.velocity = new Vector2(0, speed);
            }
            else if (hit.distance >= maxHeight)
            {
                rb.velocity = new Vector2(0, -speed);
            }
        }
    }
}