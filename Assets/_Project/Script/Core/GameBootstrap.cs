using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private string firstScene = "Scn_World";

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
        // Ambil input dan pasang ke WorldInstaller
        IMoveInput moveInput = new InputSystemMoveInput();
        
        // Beri sedikit jeda frame agar WorldInstaller siap
        StartCoroutine(InstallRoutine(moveInput));
    }

    System.Collections.IEnumerator InstallRoutine(IMoveInput moveInput)
    {
        yield return null; // Tunggu 1 frame
        WorldInstaller installer = FindAnyObjectByType<WorldInstaller>();
        if (installer != null)
        {
            installer.Install(moveInput);
        }
        else
        {
            Debug.LogError("WorldInstaller TIDAK KETEMU di scene world!");
        }
    }
}