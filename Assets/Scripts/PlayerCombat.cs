using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    FlyingEnemy flyingEnemy;
    [SerializeField] GameObject monster;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    private void Awake()
    {
        flyingEnemy = monster.GetComponent<FlyingEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            attackPoint.transform.position = transform.position + new Vector3(-1, 1, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            attackPoint.transform.position = transform.position + new Vector3(1, 1, 0);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            flyingEnemy.currentHealth -= 1;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
}
