using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaEnemy : MonoBehaviour
{
    private GameObject enemyInRange;
    public GameObject player;
    public float detectionRange = 12f;
    [SerializeField] float stopDistance = 1f;
    public float speed = 40f;
    private Rigidbody2D rb;
    private Animator animator;

    private GameObject colision;
    private float distancePlayer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
        
        move();
        //Le asignamos la velocidad a nuestro objeto 
       

    }

    private void move()
    {
        animator.SetBool("atack", false);

         distancePlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distancePlayer <= detectionRange ) 
            {
            focus(player);
            if (distancePlayer > stopDistance)
                {
               
                animator.SetBool("run", true);
                // mientras el personaje este lejos

                Vector2 direction = (player.transform.position - transform.position).normalized;

                //rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
                //rb.velocity = rb.position *direction * speed * Time.fixedDeltaTime;
                rb.velocity = direction * speed * Time.fixedDeltaTime;
               
                }
            else
                {
                   if (colision != null)
                    {
                        rb.velocity = Vector2.zero;
                        animator.SetBool("run", false);
                        animator.SetBool("atack", true);
                    }
                 }

                  

        }
     

        
      

    }
    
    private void focus(GameObject obecj)
    {
        Vector3 direction = obecj.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("flecha"))
        {
            gameObject.GetComponent<HealthSystem>().TakeDamage(50);
            Debug.Log("enemigo: me pego la flecha");
     
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            //rb.velocity = Vector2.zero;
            colision = collision.gameObject;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            colision = null;
    }

    public void damage()
    {
        if (colision != null)
        {
            if (colision.gameObject.CompareTag("Player"))
            {
                
                HealthSystem HealthPlayer = colision.gameObject.GetComponent<HealthSystem>();
                if (HealthPlayer.currentHealth > 0)
                {
                    HealthPlayer.TakeDamage(25);
                    GameManager.Instance.PerderVida();
                }
                else
                {
                    animator.SetBool("atack", false);
                }

               
               
            }
        }
    }


}
