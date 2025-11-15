using UnityEngine;

public class CommonEvents : MonoBehaviour
{
    [SerializeField] GameObject gameObjectAffected;
    [SerializeField] Interactable interactableAffected;
    [SerializeField] string sound;
    Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void ToggleActive()
    {
        gameObjectAffected.SetActive(!gameObjectAffected.activeInHierarchy);
    }

    public void PlaySound()
    {
        AudioManager.instance.PlaySound(sound);
    }

    public void ToggleMinigameOverlay()
    {
        player.minigameOverlayActive = !player.minigameOverlayActive;
    }

    public void ToggleIsPossible()
    {
        interactableAffected.isPossible = !interactableAffected.isPossible;
    }
}
