using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handling : MonoBehaviour {

    // Tracks items held, temp variable
    int itemsHeld = 0;

    // Returns held items
    public int GetItems()
    {
        return itemsHeld;
    }

    // Stow a held item
    public void Stow(GameObject heldItem)
    {
        if (heldItem != null)
        {
            Destroy(heldItem);
            Debug.Log("Stowed " + heldItem + ".");
        }
        else
        {
            Debug.Log("No item to stow.");
        }
    }
}