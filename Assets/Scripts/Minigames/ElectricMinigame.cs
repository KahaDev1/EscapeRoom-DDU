using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElectricMinigame : MonoBehaviour
{

    [SerializeField] LayerMask overlayLayer;
    [SerializeField] Collider2D background;

    Player player;

    public List<ElectrickBrick> bricks;
    public Vector2[] positions;
    public Vector2 emptyPos;

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

    public void CheckIfWon()
    {
        FindObjectWithVector(Vector2.down, Vector2.up);
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
        }
    }

    void YouWin()
    {
        Debug.Log("you did it");
    }
}
