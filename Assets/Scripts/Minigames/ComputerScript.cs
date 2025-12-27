using UnityEngine;
using UnityEngine.EventSystems;

public class ComputerScript : MonoBehaviour
, IPointerEnterHandler
, IPointerExitHandler
{

    Player player;

    [SerializeField] LayerMask overlayLayer;
    [SerializeField] Collider2D background;
    bool hoveringOverlay;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!hoveringOverlay)
            {
                player.minigameOverlayActive = false;
                gameObject.SetActive(false);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoveringOverlay = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hoveringOverlay = false;
    }
}
