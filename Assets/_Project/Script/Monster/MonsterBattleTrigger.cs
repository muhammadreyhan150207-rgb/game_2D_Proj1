using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterBattleTrigger : MonoBehaviour
{
    [Header("Battle Settings")]
    [SerializeField] private string battleSceneName = "Scn_Battle";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TriggerBattle(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerBattle(collision.gameObject);
    }

    private void TriggerBattle(GameObject target)
    {
        if (target.CompareTag("Player"))
        {
            Debug.Log($"Monster bersentuhan dengan Player! Berpindah ke {battleSceneName}...");
            SceneManager.LoadScene(battleSceneName);
        }
    }
}