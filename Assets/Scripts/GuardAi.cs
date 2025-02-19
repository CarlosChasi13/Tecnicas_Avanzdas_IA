using UnityEngine;
using UnityEngine.AI;

public class GuardAi : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform[] patrolPoints;
    public Transform player;
    private NavMeshAgent agent;
    private int currentPoint = 0;
    private bool chasing = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (patrolPoints == null || patrolPoints.Length == 0)
        {
            Debug.LogError("No hay puntos de patrulla asignados en " + gameObject.name);
            return; // Evita que se intente usar un array vacío
        }

        agent.SetDestination(patrolPoints[currentPoint].position);
    }


    // Update is called once per frame
    void Update()
    {
        if (chasing)
        {
            agent.SetDestination(player.position);
            if (Vector3.Distance(transform.position, player.position) > 10f)
            {
                chasing = false;
                GoToNextPatrolPoint();
            }
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GoToNextPatrolPoint();
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;
        agent.SetDestination(patrolPoints[currentPoint].position);
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            chasing = true;
        }
    }

}

