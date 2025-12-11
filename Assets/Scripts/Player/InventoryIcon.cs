using UnityEngine;

public class InventoryIcon : MonoBehaviour
{

    public int index;
    public Inventory inventoryManager;

    void Start()
    {

    }


    public void ClickIcon()
    {
        inventoryManager.IconClicked(index);
    }
}
