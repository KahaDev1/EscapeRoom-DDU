using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        CursorManager.instance.SetToMode(CursorManager.ModeOfCursor.Active);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CursorManager.instance.SetToMode(CursorManager.ModeOfCursor.Default);
    }

    public void ObjectGone()
    {
        CursorManager.instance.SetToMode(CursorManager.ModeOfCursor.Default);
    }

    public UnityEvent alwaysInteractableEvent;
    public UnityEvent possibleInteractableEvent;
    public UnityEvent notPossibleInteractableEvent;

    public float stopDist;
    public bool isPossible;

    public string[] linesA;
    public string[] tooDarkLine;

    Dialouge dialougeManager;
    Player player;

    void Start()
    {
        player = player = FindAnyObjectByType<Player>();
        dialougeManager = FindFirstObjectByType<Dialouge>();
    }


    public void Dialouge()
    {
        if (player.isDark)
        {
            dialougeManager.StartDialouge(tooDarkLine);
        }
        else
        {
            dialougeManager.StartDialouge(linesA);
        }
    }

    public void InvokeEvent()
    {
        if (isPossible)
        {
            possibleInteractableEvent.Invoke();
        }
        else
        {
            notPossibleInteractableEvent.Invoke();
        }
        alwaysInteractableEvent.Invoke();
    }
}
