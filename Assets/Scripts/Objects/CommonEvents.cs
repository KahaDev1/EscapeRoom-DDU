using System.Collections.Generic;
using UnityEngine;

public class CommonEvents : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjectsAffected;

    [SerializeField] List<Interactable> interactablesAffected;

    [SerializeField] string sound;
    Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void ToggleActive()
    {
        for (int i = 0; i < gameObjectsAffected.Count; i++)
        {
            gameObjectsAffected[i].SetActive(!gameObjectsAffected[i].activeInHierarchy);
        }
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
        for (int i = 0; i < interactablesAffected.Count; i++)
        {
            interactablesAffected[i].isPossible = !interactablesAffected[i].isPossible;
        }
    }

    public void SetIsPossibleFalse()
    {
        for (int i = 0; i < interactablesAffected.Count; i++)
        {
            interactablesAffected[i].isPossible = false;
        }
    }

    public void SetIsPossibleTrue()
    {
        for (int i = 0; i < interactablesAffected.Count; i++)
        {
            interactablesAffected[i].isPossible = true;
        }
    }

    public void SetActiveFalse()
    {
        for (int i = 0; i < gameObjectsAffected.Count; i++)
        {
            gameObjectsAffected[i].SetActive(false);
        }
    }
    public void SetActiveTrue()
    {
        for (int i = 0; i < gameObjectsAffected.Count; i++)
        {
            gameObjectsAffected[i].SetActive(true);
        }
    }
}
