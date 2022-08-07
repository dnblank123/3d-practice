using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;


    void Start()
    {
        currentHealth = maxHealth;
    }


    void Update()
    {
        
    }
    private void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            //no animation atm
            Destroy(gameObject);

        }

    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Sword")
        {

            TakeDamage(5);
            
        }
        

    }
}