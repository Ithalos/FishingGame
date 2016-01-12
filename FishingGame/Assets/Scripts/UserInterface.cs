using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour 
{
    public GameObject inventoryUI;
    bool inventoryOpen;

	void Start () 
    {
        // SET THIS TO FALSE ONCE FEATURE-CRAFTING IS COMPLETE!
        inventoryOpen = true;
	}
	

	void Update () 
    {
        if (Input.GetButtonDown("Inventory"))
        {
            ToggleInventory();
        }

        /*
        if (inventoryOpen)
        {
            inventoryUI.SetActive(true);
        }
        else
        {
            inventoryUI.SetActive(false);
        }
        */
	}

    void ToggleInventory()
    {
        inventoryOpen = !inventoryOpen;

        if (inventoryOpen)
        {
            inventoryUI.SetActive(true);
        }
        else
        {
            inventoryUI.SetActive(false);
        }
    }

}
