using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handling : MonoBehaviour {

    // Tracks items held, temp variable
    public int itemsHeld = 0;

    // Adds an item to hand
    public void AddItem(RaycastHit hit)
    {
        RaycastHit _hit = hit;

        // Add item to hand
        itemsHeld++;

        Debug.Log(_hit.collider.name + " picked up.");                                      //Debug Log

        // Remove item from world
        Destroy(_hit.collider.gameObject);
    }

    // Returns held items
    public int GetItems()
    {
        return itemsHeld;
    }

    // Stow a held item
    public void Stow()
    {
        if (itemsHeld > 0)
        {
            itemsHeld--;
            Debug.Log("Stow item(s) held.");
        }
        else
        {
            Debug.Log("No item to stow.");
        }
    }
}