using UnityEngine;

public class ElectricMinigame : MonoBehaviour
{

    [SerializeField] LayerMask overlayLayer;
    [SerializeField] Collider2D background;

    Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }


    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D detectedCollider = Physics2D.OverlapPoint(mousePos, overlayLayer);
            if (detectedCollider != background)
            {
                player.minigameOverlayActive = false;
                gameObject.SetActive(false);
            }
        }
    }
}
