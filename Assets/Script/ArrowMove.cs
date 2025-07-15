using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour

{
   
    public float speed = 10f; // Velocidad de la flecha
    private Vector2 direction; // Direcci�n en la que se mover�
    private float destroyTime = 2f; // Tiempo antes de destruir la flecha (en segundos)

    // Start is called before the first frame update
    void Start()
    {
        // Destruye la flecha despu�s de 'destroyTime' segundos
       
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve la flecha en la direcci�n asignada
        //Destroy(gameObject, destroyTime);
        transform.Translate(direction * speed * Time.deltaTime);
    }

    // M�todo para definir la direcci�n (llamado desde el script del arquero)
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized; // Normalizamos para evitar velocidades extra�as
        Destroy(gameObject, destroyTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Goblin"))
        {
          

            Debug.Log("toque al enemigo");
            Destroy(gameObject);
        }
    }


}
