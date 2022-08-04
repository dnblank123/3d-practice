using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update 
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    //animation
    private Animator animator;
    int isRunHash;
    int isRunBackHash;

    int isRunLeftHash;
    int isRunRightHash;
    int isAttackHash;

    private void Awake()
    {
        player = GameObject.Find("manlapulapu").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void Start() 
    {
        animator = GetComponent<Animator>();
        isRunHash = Animator.StringToHash("isRun");
        isRunBackHash = Animator.StringToHash("isRunBack");
        isRunLeftHash = Animator.StringToHash("isRunLeft");
        isRunRightHash = Animator.StringToHash("isRunRight");
        isAttackHash = Animator.StringToHash("isAttack");
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
            
        if (walkPointSet)
            agent.SetDestination(walkPoint);
           
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        animator.SetBool("isRun", true);

    }

    private void AttackPlayer()
    {
        bool isAttack = animator.GetBool("isAttack");
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        animator.SetBool("isRun", false);

        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
 
        if (!alreadyAttacked)
        {
            ///Attack code here
            animator.SetBool("isAttack", false);

            ///End of attack code
        
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            animator.SetBool("isAttack", true);
        }

        
    }
    private void ResetAttack()
    {     
        alreadyAttacked = false;  
    }


}
