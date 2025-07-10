using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMove : MonoBehaviour
{
    private int movimientoHorizontal = 0;
    private int movimientoVertical = 0;
    private Vector2 mov = new Vector2(0, 0);
    public float speed = 150;
    private Animator animator;
    private Rigidbody2D rb;
    private GameObject enemyInRange;
    public GameObject respawn;
    public GameObject arrowPrefab; // Prefab de la flecha 
    public Transform spawnPoint;   // Punto de spawn de la flecha 
    public float arrowSpeed = 40f; // Velocidad de la flecha

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
       
         attack();

     
    }

    private void FixedUpdate()
    {
        move();
        //Le asignamos la velocidad a nuestro objeto 
        rb.velocity = mov * speed * Time.fixedDeltaTime;

    }

    private void move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movimientoVertical = 1;
            
           
        }

        else if (Input.GetKey(KeyCode.S))
        { movimientoVertical = (-1); }
        else { movimientoVertical = 0; } //puesto en el else 

        //Movimiento Horizontal
        if (Input.GetKey(KeyCode.D))
        {
            movimientoHorizontal = 1;
            transform.localScale = new Vector3(1, 1, 1); // para que gire
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movimientoHorizontal = (-1);
            transform.localScale = new Vector3(-1, 1, 1); // para que gire
        }
        else { movimientoHorizontal = 0; }//puesto en el else
                                          //
        animator.SetBool("runnig", movimientoHorizontal != 0 || movimientoVertical != 0);
       //animator.SetBool("up", movimientoVertical == 1);
       // animator.SetBool("down", movimientoVertical == -1);
        //animator.SetBool("runnig", movimientoVertical != 0);

        mov = new Vector2(movimientoHorizontal, movimientoVertical);
        mov = mov.normalized;
    }

     void attack()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
           
           
            animator.SetBool("attack", true);
            
              //ShootArrow();


            if (enemyInRange != null)
            {
                enemyInRange.GetComponent<HealthSystem>().TakeDamage(20);
                Debug.Log("¡Golpeaste al enemigo!");
            }
            
        }
        else { animator.SetBool("attack", false); }
          
       

       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Goblin"))
        {
            enemyInRange = collision.gameObject;
            Debug.Log("toque al enemigo");
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == enemyInRange)
        {
            enemyInRange = null;
        }
    }

    public void respawnWarrior()
    {
        
        Vector2 direRespawn = respawn.transform.position;
        rb.MovePosition(direRespawn);
    }

    public void ShootArrow()
    {
        // 1. Instanciar la flecha
        GameObject arrow = Instantiate(arrowPrefab, spawnPoint.position, Quaternion.identity);

        // 2. Determinar la dirección del disparo (basado en la rotación del personaje)
        Vector2 shootDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

        // 3. Rotar la flecha para que coincida con la dirección
        //float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;


        // 4. Asignar dirección al script de movimiento de la flecha
        ArrowMove arrowScript = arrow.GetComponent<ArrowMove>();
        if (arrowScript != null)
        {
            arrowScript.SetDirection(shootDirection);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("salud"))
            if (gameObject.GetComponent<HealthSystem>().currentHealth < 100)
            {
                {
                    gameObject.GetComponent<HealthSystem>().currentHealth += 25;
                    Debug.Log("el jugador se curo 25 de vida.. vida actual: " + gameObject.GetComponent<HealthSystem>().currentHealth);
                    GameManager.Instance.RecuperarVida();
                    collision.gameObject.SetActive(false);
                }
            }
    }

}

