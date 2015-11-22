using UnityEngine;
using System.Collections;

public class UserInterface : MonoBehaviour 
{
    public GameObject inventoryUI;
    bool inventoryOpen;

	void Start () 
    {
        inventoryOpen = false;
	}
	

	void Update () 
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryOpen = !inventoryOpen;
        }

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
