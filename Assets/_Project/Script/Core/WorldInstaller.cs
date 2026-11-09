using UnityEngine;

public class WorldInstaller : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerInteractor interactor;
    [SerializeField] private MonsterData debugStarter;

    public void Install(IMoveInput moveInput, IActionInput actionInput)
    {
        if (player != null && moveInput != null)
        {
            player.Construct(moveInput);
        }

        if (interactor != null && actionInput != null)
        {
            interactor.Construct(actionInput);
        }
    }
}