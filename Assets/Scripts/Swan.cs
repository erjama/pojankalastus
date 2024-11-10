using UnityEngine;
using UnityEngine.AI;

public class Swan : MonoBehaviour
{
    public Transform[] waypoints;     // Array of waypoints for patrol
    public float patrolSpeed = 2f;    // Speed of enemy when patrolling
    public float attackSpeed = 4;
    public float attackRange = 10f;    // Distance at which enemy starts attacking
    [SerializeField] AudioClip angrySound;
    private bool isAttacking = false;

    private int currentWaypointIndex = 0;
    private NavMeshAgent navAgent;    // NavMeshAgent for movement
    private float nextAttackTime = 0f;
    [SerializeField] private Transform mummo;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform startpoint;
    [SerializeField] FirstPersonController firstPersonController;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.speed = patrolSpeed;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, mummo.position);

        if (distanceToPlayer <= attackRange)
        {
            // If player is close, attack
            AttackPlayer();
        }
        else
        {
            // Otherwise, keep patrolling
            Patrol();
        }
    }

    void Patrol()
    {
        if (navAgent.remainingDistance < 0.5f && !navAgent.pathPending)
        {
            // Move to the next waypoint
            StopAttacking();
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }

    void AttackPlayer()
    {
        if (Time.time >= nextAttackTime)
        {
            navAgent.speed = attackSpeed;
            navAgent.SetDestination(mummo.position);
            if (isAttacking == false)
            {
                StartAttacking();
            }

            // Check if close enough to "attack"
            if (IsCloseEnoughToHitting())
            {
                Debug.Log("Hitting player");
                StopAttacking();
                firstPersonController.transformPlayerToStart();
                navAgent.speed = patrolSpeed;
                navAgent.SetDestination(waypoints[currentWaypointIndex].position);
            }
        }
    }

    private bool IsCloseEnoughToHitting()
    {
        return navAgent.remainingDistance <= navAgent.stoppingDistance;
    }

    private void StartAttacking()
    {
        animator.SetBool("playerIsOnRange", true);
        AudioManager.instance.Play(angrySound);
        isAttacking = true;
    }

    private void StopAttacking()
    {
        isAttacking = false;
        animator.SetBool("playerIsOnRange", false);
    }
}
