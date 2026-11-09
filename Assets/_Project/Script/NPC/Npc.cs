using UnityEngine;

public class Npc : MonoBehaviour, IInteractable
{
    [SerializeField] private string npcName = "Warga Desa";
    [SerializeField] [TextArea] private string dialogue = "Halo, selamat datang di pelabuhan!";

    public void Interact(PlayerInteractor who)
    {
        Debug.Log($"[{npcName}] Berbicara dengan player: \"{dialogue}\"");
        
        // Di sini nanti bisa dipanggil UI Dialog atau sistem quest FishMarket
    }
}