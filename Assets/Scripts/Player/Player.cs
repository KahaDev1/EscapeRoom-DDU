using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    Interactable currentInteraction;

    [SerializeField] float moveSpeed;
    bool moveToDestination;
    float destination;
    float reachDestinationValue = 0.1f;

    Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    [SerializeField] LayerMask interactableLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D detectedCollider = Physics2D.OverlapPoint(mousePos, interactableLayer);
            if (detectedCollider)
            {
                Interactable newInteractable = detectedCollider.GetComponent<Interactable>();
                if (newInteractable)
                {
                    StartMoveTo(newInteractable.transform.position.x, newInteractable.stopDist, newInteractable);
                }
            }
            else
            {
                destination = mousePos.x;
                reachDestinationValue = 0.1f;
            }
            moveToDestination = true;
        }

        HandleVisual();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        if (moveToDestination)
        {
            float dir = 1;
            if (transform.position.x > destination)
            {
                dir = -1;
            }
            Vector2 force = new Vector2(dir, 0);
            rb.AddForce(force * moveSpeed);

            if (Mathf.Abs(transform.position.x - destination) < reachDestinationValue)
            {
                moveToDestination = false;
            }
        }
    }

    void HandleVisual()
    {
        if (rb.linearVelocityX > 0.1f)
        {
            spriteRenderer.flipX = false;
            animator.Play("Walk");
        }
        else if (rb.linearVelocityX < -0.1f)
        {
            spriteRenderer.flipX = true;
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");
        }

    }

    public void StartMoveTo(float xDestination, float stopDistance, Interactable objectPressed)
    {
        destination = xDestination;
        reachDestinationValue = stopDistance;
        currentInteraction = objectPressed;
    }

}
