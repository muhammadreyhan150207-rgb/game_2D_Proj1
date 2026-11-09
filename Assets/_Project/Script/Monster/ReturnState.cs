using UnityEngine;

public class ReturnState : IState
{
    private MonsterAI monster;
    private StateMachine stateMachine;
    private float speed = 1.5f;

    public ReturnState(MonsterAI monster, StateMachine stateMachine)
    {
        this.monster = monster;
        this.stateMachine = stateMachine;
    }

    public void Enter() { }

    public void Tick()
    {
        float distanceToStart = Vector2.Distance(monster.transform.position, monster.StartPosition);

        // Jika sudah sampai dekat posisi awal, kembali berpatroli (Wander State)
        if (distanceToStart <= 0.1f)
        {
            // Transisi kembali ke WanderState
            return;
        }

        // Berjalan kembali ke titik awal spawn
        monster.transform.position = Vector2.MoveTowards(
            monster.transform.position, 
            monster.StartPosition, 
            speed * Time.deltaTime
        );
    }

    public void Exit() { }
}