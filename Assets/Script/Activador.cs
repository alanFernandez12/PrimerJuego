using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activador : MonoBehaviour
{
    public Transform spawnPoint;   // Punto de spawn de la flecha 
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2o(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player entró");
            for(int i = 0; i < 4; i++)
            {
                GameObject enemys = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
                IaEnemy en = enemys.GetComponent<IaEnemy>();

                if(en != null)
                {
                    en.player = collision.gameObject;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("player entró");
            for (int i = 0; i < 4; i++)
            {
                GameObject enemys = Instantiate(enemy, spawnPoint.position, Quaternion.identity);
                IaEnemy en = enemys.GetComponent<IaEnemy>();

                if (en != null)
                {
                    en.player = collision.gameObject;
                }
                gameObject.SetActive(false);
            }
        }

    }
}
