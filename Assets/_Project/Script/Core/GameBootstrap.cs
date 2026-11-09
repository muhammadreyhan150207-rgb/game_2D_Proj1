using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private WorldInstaller worldInstaller;

    private void Awake()
    {
        if (worldInstaller == null)
        {
            worldInstaller = FindFirstObjectByType<WorldInstaller>();
        }

        if (worldInstaller != null)
        {
            // Menggunakan kelas input yang sesuai dengan project-mu
            IMoveInput moveInput = new InputSystemMoveInput();
            IActionInput actionInput = new InputSystemActionInput();

            worldInstaller.Install(moveInput, actionInput);
        }
    }
}