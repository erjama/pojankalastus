
using UnityEngine;
using UnityEngine.AI;

public class Swan : MonoBehaviour
{
    public Transform[] waypoints;     // Array of waypoints for patrol
    public float patrolSpeed = 2f;    // Speed of enemy when patrolling
    public float attackRange = 10f;    // Distance at which enemy starts attacking
    public float attackSpeed = 3.5f;  // Speed of enemy when attacking
    public float attackCooldown = 2f; // Cooldown between attacks

    private int currentWaypointIndex = 0;
    private NavMeshAgent navAgent;    // NavMeshAgent for movement
    private bool isAttacking = false;
    private float nextAttackTime = 0f;
    [SerializeField] private Transform mummo;

    void Start() {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = patrolSpeed;
    }

    void Update() {


        float distanceToPlayer = Vector3.Distance(transform.position, mummo.position);
  
        if (distanceToPlayer <= attackRange) {
            // If player is close, attack
            AttackPlayer();
        } else {
            // Otherwise, keep patrolling
            Patrol();
        }
    }

    void Patrol() {
        if (navAgent.remainingDistance < 0.5f && !navAgent.pathPending) {
            // Move to the next waypoint
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void AttackPlayer() {
        if (Time.time >= nextAttackTime) {
            navAgent.speed = attackSpeed;
            navAgent.SetDestination(mummo.position);

            // Check if close enough to "attack"
            if (navAgent.remainingDistance <= navAgent.stoppingDistance) {
                // Implement attack here, like reducing player health
                Debug.Log("Attacking the player!");
                nextAttackTime = Time.time + attackCooldown;
            }
        }
    }
}
