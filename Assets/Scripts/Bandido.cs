using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandido : MonoBehaviour
{
   public int maxHealth = 100;
   int currentHealth;
   private Animator anim;
   //ATAQUES;
   void Start()
    {   
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
       
    }

    public void TakeDamage(int damage)
   {
       currentHealth -= damage;
       anim.SetTrigger("Hurt");
       if(currentHealth <= 0)
       {   
            
           Die();
       }

   }   
    void Die()
    {   
        anim.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject, 1f);   
    }
}
