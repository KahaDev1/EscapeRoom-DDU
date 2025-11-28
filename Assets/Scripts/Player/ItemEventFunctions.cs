using UnityEngine;

public class ItemEventFunctions : MonoBehaviour
{
    public Inventory inventory;
    public Item thisItem;

    public void AddItemToInventory()
    {
        inventory.AddItem(thisItem);
    }
}
