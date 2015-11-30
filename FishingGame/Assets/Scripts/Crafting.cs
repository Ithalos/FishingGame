using UnityEngine;
using System.Collections;

public class Crafting : MonoBehaviour
{
    public GameObject inventoryObject;
    Inventory inventory;
    

    void Start()
    {
        inventory = inventoryObject.GetComponent<Inventory>();
    }

    public void CraftFireplace()
    {
        string stickName = "wooden_stick";
        string matchName = "match";

        string stickID = "";
        int matchID;

        bool haveStick = false;
        bool haveMatch = false; 

        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].Slug == stickName)
            {
                stickID = inventory.slots[i].ToString();
                haveStick = true;
            }
            if (inventory.items[i].Slug == matchName)
            {
                matchID = inventory.items[i].ID;
                haveMatch = true;
            }

            if (haveStick && haveMatch)
            {
                Debug.Log(stickID);
                // Debug.Log(matchID);
                inventory.AddItem(0);
                break;
            }
        }
    }
}
