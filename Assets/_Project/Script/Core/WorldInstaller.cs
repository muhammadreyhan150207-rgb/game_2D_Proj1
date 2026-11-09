using UnityEngine;

public class WorldInstaller : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private PlayerInteractor interactor; // Tambahkan referensi interactor

    public void Install(IMoveInput moveInput, IActionInput actionInput)
    {
        player.Construct(moveInput);
        
        if (interactor != null)
        {
            interactor.Construct(actionInput); // Suntikkan action input ke interactor
        }
        else
        {
            Debug.LogError("PlayerInteractor belum di-assign di Inspector WorldInstaller!");
        }
    }
}