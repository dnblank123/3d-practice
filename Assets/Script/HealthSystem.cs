using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Animator Anim;



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
            Anim.SetBool("isDead", true);
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
