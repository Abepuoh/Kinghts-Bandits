using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Caballero : MonoBehaviour
{   
    public static int numberOfCoins;
     
    public float JumpForce = 7f;
    public float Speed = 10f;
    private Rigidbody2D rb;
    private float Horizontal;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    private bool Grounded;
    private Animator Animator;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    public TextMeshProUGUI coinText;

    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        coinText.text = "x"+numberOfCoins;
        Horizontal = Input.GetAxis("Horizontal");   

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        
        Animator.SetBool("running", Horizontal != 0.0f);

        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if(Input.GetKeyDown("space") && Grounded)
        {
           Jump();
        }
        if(Time.time  >= nextAttackTime)
        {
             if(Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }        
    }
    private void Attack()
    {
        Animator.SetTrigger("attack");
        Collider2D [] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {   
            enemy.GetComponent<Bandido>().TakeDamage(30);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
    private void Jump()
    {   
        Animator.SetTrigger("jump");
        Grounded = false;
        Animator.SetBool("Grounded", Grounded);
        rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {   
        rb.velocity = new Vector2(Horizontal * 5, rb.velocity.y);
    } 
}
