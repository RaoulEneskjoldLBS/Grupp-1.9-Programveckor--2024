using UnityEngine;
using UnityEngine.AI;

public class Pathfinding : MonoBehaviour
{
    [SerializeField] Transform target;
    public float initialDetectionRange = 10f;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        // Check if the target is within the detection range
        if (distanceToTarget <= initialDetectionRange)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            // Optionally, you can add code here to handle what happens when the target is out of range.
            // For example, you might stop the enemy or perform other actions.
            // agent.SetDestination(transform.position); // Stop the enemy (optional)
        }
    }
}

