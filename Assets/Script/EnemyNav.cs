using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent agent;
    [SerializeField] public float detectionRange = 4f;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Si el jugador está en rango de detección, persíguelo
        if (distanceToTarget <= detectionRange)
        {
           
            agent.SetDestination(target.position);
        }
       

    }
  
}
