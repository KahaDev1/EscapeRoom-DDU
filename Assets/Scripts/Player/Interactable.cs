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

    public UnityEvent interactableEvent;

    public float stopDist;

    void Start()
    {

    }


    void Update()
    {

    }
}
