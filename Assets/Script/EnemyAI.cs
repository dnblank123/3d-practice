using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
    int isDeadHash;
    int CurrentWaypointIndex;
    
    public HealthSystem EnemyHealth;
    public GameObject EnemyObj;
    public GameObject CutsceneCamera;
    public GameObject EnemyCanvas;
    public GameObject LapuCanvas;
    

    private void Awake()
    {
        player = GameObject.Find("HumanMale").transform;
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
        isDeadHash = Animator.StringToHash("isDead");
        CurrentWaypointIndex = 0;
        
    }

    private void LateUpdate()
    {
        bool isDead = animator.GetBool("isDead");
        if (EnemyHealth.currentHealth == 5) RunToTheCutscene();
        //if (EnemyHealth.currentHealth <= 0 && !isDead) HealthZeroAnimation();
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
            Invoke(nameof(FixStuck), 5f);
            animator.SetBool("isRun", true);
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        walkPointSet = false;
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
    private void HealthZeroAnimation()
    {
        if(EnemyHealth.currentHealth <=0)
        {
            animator.SetTrigger("isDead");
            EnemyObj.GetComponent<EnemyAI>().enabled = false;
            EnemyObj.GetComponent<HealthSystem>().enabled = false;
            Invoke(nameof(DisableOnDead), 4f);

        }

        
    }
    private void RunToTheCutscene()
    {
        if(EnemyHealth.currentHealth <= 5)
        {
            CutsceneCamera.SetActive(true);
            Invoke(nameof(NextSceneInvoke), 10f);
            EnemyCanvas.SetActive(false);
            LapuCanvas.SetActive(false);
        }
    }
    protected void DisableOnDead()
    {
        EnemyObj.GetComponent<Collider>().enabled = false;
        EnemyObj.GetComponent<NavMeshAgent>().enabled = false;
    }
    public void FixStuck()
    {
        walkPointSet = false;
    }
    private void NextSceneInvoke()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
