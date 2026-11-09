using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public enum BattleState { START, PLAYER_TURN, ENEMY_TURN, WON, LOST }
    
    [Header("Current Battle State")]
    public BattleState state;

    private void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    private void SetupBattle()
    {
        Debug.Log("Pertempuran dimulai! Menyiapkan data petarung...");
        
        // Langsung masuk ke giliran Player untuk uji coba awal
        state = BattleState.PLAYER_TURN;
    }

    // Fungsi yang dipanggil saat Player menekan tombol Serang (Attack)
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYER_TURN) return;

        StartCoroutine(PlayerAttackRoutine());
    }

    private System.Collections.IEnumerator PlayerAttackRoutine()
    {
        Debug.Log("Player menyerang monster!");

        // Beri jeda sebentar untuk simulasi aksi
        yield return new WaitForSeconds(1f);

        // Ubah giliran ke Enemy/Monster
        state = BattleState.ENEMY_TURN;
        StartCoroutine(EnemyTurnRoutine());
    }

    private System.Collections.IEnumerator EnemyTurnRoutine()
    {
        Debug.Log("Giliran Monster Pyrit menyerang!");

        yield return new WaitForSeconds(1f);

        // Kembalikan giliran ke Player
        state = BattleState.PLAYER_TURN;
    }

    // Fungsi untuk kabur kembali ke Scn_World
    public void OnRunButton()
    {
        Debug.Log("Kabur dari pertempuran! Kembali ke Scn_World...");
        SceneManager.LoadScene("Scn_World");
    }
}