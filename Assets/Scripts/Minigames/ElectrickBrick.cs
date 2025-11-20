using System.Collections.Generic;
using UnityEngine;

public class ElectrickBrick : MonoBehaviour
{

    public Collider2D collider2d;
    [SerializeField] LayerMask bricklayer;

    public Vector2 dirA1;
    public Vector2 dirA2;
    public Vector2 dirB1;
    public Vector2 dirB2;
    public List<Vector2> directionsA;
    public List<Vector2> directionsB;

    [SerializeField] ElectricMinigame minigameHandler;
    public Vector2 currentPos;

    bool holdingBrick;
    float timer;
    float clickTime = 0.3f;

    void Start()
    {
        directionsA.Add(dirA1);
        directionsA.Add(dirA2);
        directionsB.Add(dirB1);
        directionsB.Add(dirB2);
        collider2d = GetComponent<Collider2D>();
        currentPos = transform.position;
        minigameHandler.bricks.Add(this);
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D detectedCollider = Physics2D.OverlapPoint(mousePos, bricklayer);
            if (detectedCollider == collider2d)
            {
                if (Vector2.Distance(currentPos, minigameHandler.emptyPos) < 1.1f)
                {
                    holdingBrick = true;
                    timer = 0;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (holdingBrick && ((Vector2)transform.position != currentPos || timer < clickTime))
            {
                transform.position = minigameHandler.emptyPos;
                Vector2 oldpos = currentPos;
                currentPos = minigameHandler.emptyPos;
                minigameHandler.emptyPos = oldpos;
                minigameHandler.CheckIfWon();
            }
            holdingBrick = false;
        }
        MoveBrick();
    }

    void MoveBrick()
    {
        if (holdingBrick)
        {
            Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            float newPosX;
            float newPosY;
            if (currentPos.x < minigameHandler.emptyPos.x || currentPos.y < minigameHandler.emptyPos.y)
            {
                newPosX = Mathf.Clamp(mousePos.x, currentPos.x, minigameHandler.emptyPos.x);
                newPosY = Mathf.Clamp(mousePos.y, currentPos.y, minigameHandler.emptyPos.y);
            }
            else
            {
                newPosX = Mathf.Clamp(mousePos.x, minigameHandler.emptyPos.x, currentPos.x);
                newPosY = Mathf.Clamp(mousePos.y, minigameHandler.emptyPos.y, currentPos.y);
            }
            transform.position = new Vector3(newPosX, newPosY, transform.position.z);
            timer += Time.deltaTime;
        }
    }
}
