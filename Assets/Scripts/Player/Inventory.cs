using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //public GameObject flashlight;
    //public GameObject screwdriver;


    List<Item> items = new List<Item>();
    List<GameObject> iconGameObjects = new List<GameObject>();
    List<GameObject> itemGameObjects = new List<GameObject>();

    public int currentItemIndex = 0;

    public GameObject inventoryPanel;
    public Transform hand;

    public void AddItem(Item newItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == newItem)
            {
                return;
            }
        }

        items.Add(newItem);
        //Instantiate new panel

        GameObject newIcon = Instantiate(newItem.iconPrefab, inventoryPanel.transform);
        InventoryIcon inventoryIconComponent = newIcon.GetComponent<InventoryIcon>();
        inventoryIconComponent.index = items.Count - 1;
        inventoryIconComponent.inventoryManager = this;

        iconGameObjects.Add(newIcon);


        itemGameObjects.Add(Instantiate(newItem.itemPrefab, hand.transform));
        currentItemIndex = items.Count - 1;
    }

    public void IconClicked(int index)
    {
        if (currentItemIndex == index)
        {
            itemGameObjects[index].SetActive(false);
            currentItemIndex = -1;
        }
        else
        {
            if (currentItemIndex != -1)
            {
                itemGameObjects[currentItemIndex].SetActive(false);
            }
            itemGameObjects[index].SetActive(true);
            currentItemIndex = index;
        }
    }
}
