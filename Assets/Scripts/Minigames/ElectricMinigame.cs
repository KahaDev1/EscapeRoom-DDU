using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ElectricMinigame : MonoBehaviour
{

    public UnityEvent WinMinigameEvent;
    public UnityEvent LoseMinigameEvent;

    [SerializeField] LayerMask overlayLayer;
    [SerializeField] Collider2D background;

    [SerializeField] Sprite backgroundUnlit;
    [SerializeField] Sprite backgroundLit;
    [SerializeField] SpriteRenderer backgroundSpriteRenderer;


    Player player;

    public List<ElectrickBrick> bricks;
    List<ElectrickBrick> bricksInSequence;
    public Vector2[] positions;
    public Vector2 emptyPos;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        bricksInSequence = new List<ElectrickBrick>();
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

    public void CheckIfWon()
    {
        FindObjectWithVector(Vector2.down, Vector2.up);
        bricksInSequence = new List<ElectrickBrick>();
    }

    void FindObjectWithVector(Vector2 pos, Vector2 inputDir, ElectrickBrick oldBrick = null)
    {
        for (int i = 0; i < bricks.Count(); i++)
        {
            ElectrickBrick brick = bricks[i];
            if (oldBrick != brick)
            {
                if (brick.currentPos == pos)
                {
                    bricksInSequence.Add(brick);
                    if (brick.currentPos == Vector2.up)
                    {
                        if (brick.dirA1 == inputDir * -1)
                        {
                            if (brick.dirA2 == Vector2.up)
                            {
                                YouWin();
                                return;
                            }
                        }
                        else if (brick.dirA2 == inputDir * -1)
                        {
                            if (brick.dirA1 == Vector2.up)
                            {
                                YouWin();
                                return;
                            }
                        }
                        else if (brick.dirB1 == inputDir * -1)
                        {
                            if (brick.dirB2 == Vector2.up)
                            {
                                YouWin();
                                return;
                            }
                        }
                        else if (brick.dirB2 == inputDir * -1)
                        {
                            if (brick.dirB1 == Vector2.up)
                            {
                                YouWin();
                                return;
                            }
                        }
                    }
                    if (brick.dirA1 == inputDir * -1)
                    {
                        FindObjectWithVector(brick.currentPos + brick.dirA2, brick.dirA2, brick);
                    }
                    else if (brick.dirA2 == inputDir * -1)
                    {
                        FindObjectWithVector(brick.currentPos + brick.dirA1, brick.dirA1, brick);
                    }
                    else if (brick.dirB1 == inputDir * -1)
                    {
                        FindObjectWithVector(brick.currentPos + brick.dirB2, brick.dirB2, brick);
                    }
                    else if (brick.dirB2 == inputDir * -1)
                    {
                        FindObjectWithVector(brick.currentPos + brick.dirB1, brick.dirB1, brick);
                    }
                    return;
                }
            }
            YouLose();
        }
    }

    void YouWin()
    {
        backgroundSpriteRenderer.sprite = backgroundLit;
        WinMinigameEvent.Invoke();
        for (int i = 0; i < bricksInSequence.Count(); i++)
        {
            bricksInSequence[i].spriteRenderer.sprite = bricksInSequence[i].lit;
        }
    }
    void YouLose()
    {
        backgroundSpriteRenderer.sprite = backgroundUnlit;
        LoseMinigameEvent.Invoke();
        for (int i = 0; i < bricks.Count(); i++)
        {
            bricks[i].spriteRenderer.sprite = bricks[i].unlit;
        }
    }
}
