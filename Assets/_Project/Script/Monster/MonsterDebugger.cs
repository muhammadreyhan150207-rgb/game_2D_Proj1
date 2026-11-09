using UnityEngine;

public class MonsterDebugger : MonoBehaviour
{
    [SerializeField] private MonsterData species;
    [SerializeField] private int level = 3;
    private MonsterInstance monster;

    [ContextMenu("1. Buat Monster")]
    public void CreateMonster()
    {
        if (species == null) return;
        monster = new MonsterInstance(species, level);
        Debug.Log($"Monster dibuat: {monster.Data.DisplayName} (Lv {monster.Level}), HP: {monster.MaxHP}");
    }

    [ContextMenu("3. Beri 100 EXP")]
    public void GiveExp()
    {
        if (monster == null)
        {
            Debug.LogWarning("Buat monster terlebih dahulu!");
            return;
        }
        monster.GainExp(100);
    }
}