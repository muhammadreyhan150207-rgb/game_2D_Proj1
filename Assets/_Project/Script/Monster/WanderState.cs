using UnityEngine;

public class WanderState : IState
{
    private MonsterAI monster;
    private StateMachine stateMachine;
    private Vector2 targetPosition;
    private float timer;
    private float wanderInterval = 3f;
    private float speed = 1f;

    public WanderState(MonsterAI monster, StateMachine stateMachine)
    {
        this.monster = monster;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        GetNewDestination();
    }

    public void Tick()
    {
        // Cek jarak ke player untuk transisi ke Chase State
        if (monster.Player != null)
        {
            float distanceToPlayer = Vector2.Distance(monster.transform.position, monster.Player.position);
            if (distanceToPlayer <= monster.ChaseRange)
            {
                // Pindah ke Chase State (akan kita buat selanjutnya)
                return;
            }
        }

        // Bergerak acak secara berkala
        timer += Time.deltaTime;
        if (timer >= wanderInterval)
        {
            GetNewDestination();
            timer = 0f;
        }

        monster.transform.position = Vector2.MoveTowards(
            monster.transform.position, 
            targetPosition, 
            speed * Time.deltaTime
        );
    }

    public void Exit() { }

    private void GetNewDestination()
    {
        Vector2 randomOffset = Random.insideUnitCircle * monster.WanderRadius;
        targetPosition = (Vector2)monster.StartPosition + randomOffset;
    }
}