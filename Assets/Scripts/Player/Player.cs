using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

    GameObject currentInteraction;

    [SerializeField] float moveSpeed;
    bool moveToDestination;
    float destination;
    float reachDestinationValue = 0.1f;

    Rigidbody2D rb;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveToDestination = true;
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        }

        HandleVisual();
    }

    void FixedUpdate()
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

    public void MoveTo(float xDestination, float distance, GameObject objectPressed)
    {

    }

}
