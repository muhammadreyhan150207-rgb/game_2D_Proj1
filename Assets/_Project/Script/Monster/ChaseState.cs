using UnityEngine;

public class ChaseState : IState
{
    private MonsterAI monster;
    private StateMachine stateMachine;
    private float speed = 2f; // Kecepatan kejar lebih cepat dari wander

    public ChaseState(MonsterAI monster, StateMachine stateMachine)
    {
        this.monster = monster;
        this.stateMachine = stateMachine;
    }

    public void Enter()
    {
        monster.SetAlert(true); // Nyalakan ikon tanda seru (!)
    }

    public void Tick()
    {
        if (monster.Player == null) return;

        float distanceToPlayer = Vector2.Distance(monster.transform.position, monster.Player.position);

        // Jika player terlalu jauh, kembali ke posisi awal (Return State)
        if (distanceToPlayer > monster.ChaseRange * 1.5f)
        {
            // Transisi ke ReturnState bisa diatur di sini
            return;
        }

        // Kejar player
        monster.transform.position = Vector2.MoveTowards(
            monster.transform.position, 
            monster.Player.position, 
            speed * Time.deltaTime
        );
    }

    public void Exit()
    {
        monster.SetAlert(false); // Matikan ikon tanda seru (!) saat keluar state kejar
    }
}