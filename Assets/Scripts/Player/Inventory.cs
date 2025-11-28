using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    //public GameObject flashlight;
    //public GameObject screwdriver;


    List<Item> items = new List<Item>();

    Item currentItem;

    public GameObject inventoryPanel;
    public Transform hand;

    void Start()
    {

    }


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
        currentItem = newItem;
        //Instantiate new panel

        Instantiate(newItem.iconPrefab, inventoryPanel.transform);
        Instantiate(newItem.itemPrefab, hand.transform);
    }
}
