using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int MaxHealth = 3 ;
    [SerializeField] private int CurrentHealth ;
    
    void Start()
    { //ilk caný max cana eþitledik full canla doðsun diye 
        CurrentHealth = MaxHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage (int amount)
    {
        CurrentHealth -= amount;
        if(CurrentHealth <= 0) 
        {
            Destroy(gameObject);
        }

    }
}
