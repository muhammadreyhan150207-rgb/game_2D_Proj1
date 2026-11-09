using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private string firstScene = "Scn_World";
    private IMoveInput moveInput;
    private IActionInput actionInput; // Tambahan untuk interaksi

    void Awake()
    {
        // Cek apakah scene world sudah ke-load atau belum
        if (!SceneManager.GetSceneByName(firstScene).isLoaded)
        {
            SceneManager.LoadScene(firstScene, LoadSceneMode.Additive);
        }
    }

    void Start()
    {
        // Ambil input gerak dan input aksi/interaksi
        moveInput = new InputSystemMoveInput();
        actionInput = new InputSystemActionInput(); // Inisialisasi input interaksi

        // Beri sedikit jeda frame agar WorldInstaller siap
        StartCoroutine(InstallRoutine(moveInput, actionInput));
    }

    System.Collections.IEnumerator InstallRoutine(IMoveInput moveInput, IActionInput actionInput)
    {
        yield return null; // Tunggu 1 frame
        WorldInstaller installer = FindAnyObjectByType<WorldInstaller>();
        if (installer != null)
        {
            installer.Install(moveInput, actionInput); // Kirim keduanya ke WorldInstaller
        }
        else
        {
            Debug.LogError("WorldInstaller TIDAK KETEMU di scene world!");
        }
    }
}