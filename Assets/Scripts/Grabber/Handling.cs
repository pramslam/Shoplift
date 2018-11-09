using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handling : MonoBehaviour {

    List<GameObject> inventory;

    void Start()
    {
        inventory = new List<GameObject>();
    }

    void Update()
    {
        ListCheck();
    }

    // Stow a held item
    public void Stow(GameObject heldItem)
    {
        if (heldItem != null)
        {
            inventory.Add(heldItem);
            heldItem.SetActive(false);
            Debug.Log("Stowed " + heldItem + ".");
        }
        else
        {
            Debug.Log("No item to stow.");
        }
    }

    // Prints the current list of items
    void ListCheck()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log(inventory.Count);

            foreach(GameObject list in inventory)
            {
                if (list != null)
                {
                    Debug.Log(list.name);
                }
            }
        }
    }
}