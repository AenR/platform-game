using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;

    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (player == null)
        {
            return;
        }
        if(chase==true)
        {
            Chase();
        }
        else
        {
            ReturnStartPoint();
        }
        Flip();
        if(currentHealth<=0)
        {
            Destroy(gameObject);
        }
    }

    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, player.transform.position)<=0.5f)
        {

        }
    }
    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
