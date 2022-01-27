using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandido : MonoBehaviour
{   
   [SerializeField] private Transform[] puntosMov;
   [SerializeField] private float velocidad;
   private int i = 0;
   private Vector3 escalaIni,escalaTemp;
   private float miraDer = 1;
   public int maxHealth = 100;
   int currentHealth;
   private Animator anim;
   //ATAQUES;
   void Start()
    {   
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        escalaIni = transform.localScale;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosMov[i].transform.position, velocidad * Time.deltaTime);
  
        if(Vector2.Distance(transform.position, puntosMov[i].transform.position) < 0.1f)
        {
            if(puntosMov[i] != puntosMov[puntosMov.Length -1 ])
            {
                i++;
            }else{
                i = 0;
            }
            miraDer = Mathf.Sign(puntosMov[i].transform.position.x - transform.position.x);
            girar(miraDer);
        }
    }
    private void girar(float lado)
    {
        if(miraDer == -1){
            escalaTemp = escalaIni;
        }else{
            escalaTemp = transform.localScale;
            escalaTemp.x = escalaTemp.x * -1;
        }
        transform.localScale = escalaTemp;
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
