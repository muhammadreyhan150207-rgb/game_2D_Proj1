using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [Header("Monster Data")]
    [SerializeField] private MonsterData monsterData;
    [SerializeField] private int level = 1;

    [Header("Detection Settings")]
    [SerializeField] private float wanderRadius = 3f;
    [SerializeField] private float chaseRange = 4f;
    [SerializeField] private float attackRange = 1f;
    [SerializeField] private GameObject alertIcon; // Ikon tanda seru (!)

    private Transform playerTransform;
    private StateMachine stateMachine;
    private Vector3 startPosition;
    private MonsterInstance monsterInstance;

    // States
    private WanderState wanderState;
    private ChaseState chaseState;
    private ReturnState returnState;

    public MonsterInstance MonsterInstance => monsterInstance;
    public Transform Player => playerTransform;
    public Vector3 StartPosition => startPosition;
    public float WanderRadius => wanderRadius;
    public float ChaseRange => chaseRange;
    public float AttackRange => attackRange;

    private void Start()
    {
        startPosition = transform.position;
        monsterInstance = new MonsterInstance(monsterData, level);

        // Cari player berdasarkan tag "Player"
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerTransform = playerObj.transform;
        }

        if (alertIcon != null) alertIcon.SetActive(false);

        // Inisialisasi State Machine & States
        stateMachine = new StateMachine();
        wanderState = new WanderState(this, stateMachine);
        chaseState = new ChaseState(this, stateMachine);
        returnState = new ReturnState(this, stateMachine);

        // Mulai dari Wander State
        stateMachine.Initialize(wanderState);
    }

    private void Update()
    {
        stateMachine?.Tick();

        // Logika sederhana untuk transisi antar state di Update
        if (playerTransform != null)
        {
            float distToPlayer = Vector2.Distance(transform.position, playerTransform.position);
            float distToStart = Vector2.Distance(transform.position, startPosition);

            // Transisi Wander -> Chase
            if (distToPlayer <= chaseRange && stateMachine.CurrentState == wanderState)
            {
                stateMachine.ChangeState(chaseState);
            }
            // Transisi Chase -> Return (kalau player kabur kejauhan)
            else if (distToPlayer > chaseRange * 1.5f && stateMachine.CurrentState == chaseState)
            {
                stateMachine.ChangeState(returnState);
            }
            // Transisi Return -> Wander (kalau sudah balik ke dekat titik awal)
            else if (distToStart <= 0.1f && stateMachine.CurrentState == returnState)
            {
                stateMachine.ChangeState(wanderState);
            }
        }
    }

    public void SetAlert(bool active)
    {
        if (alertIcon != null)
        {
            alertIcon.SetActive(active);
        }
    }
}