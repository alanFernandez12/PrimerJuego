using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScriot : MonoBehaviour
{
    public Transform staticPosition;
    public GameObject player;
    private Vector3 originalOffset;
    private float originalY; // Almacenaremos la posición Y inicial
    // Start is called before the first frame update
    void Start()
    {
        originalOffset = transform.position - player.transform.position;
        originalY = transform.position.y; // Guardamos la posición Y inicial
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(
          player.transform.position.x + originalOffset.x,
          originalY, // Mantenemos la Y original
          transform.position.z // Mantenemos la Z original
         );


    }

   
}
