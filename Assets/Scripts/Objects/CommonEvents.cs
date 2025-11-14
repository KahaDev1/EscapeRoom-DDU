using UnityEngine;

public class CommonEvents : MonoBehaviour
{
    [SerializeField] GameObject gameObjectAffected;

    public void ToggleActive()
    {
        gameObjectAffected.SetActive(!gameObjectAffected.activeInHierarchy);
    }
}
