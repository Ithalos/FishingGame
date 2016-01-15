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

        bool haveStick = false;
        bool haveMatch = false; 

        for (int i = 0; i < inventory.items.Count; i++)
        {
            if (inventory.items[i].Slug == stickName)
            {
                haveStick = true;
            }
            if (inventory.items[i].Slug == matchName)
            {
                haveMatch = true;
            }
            if (haveStick && haveMatch)
            {
                inventory.RemoveItem("Wooden Stick");
                inventory.RemoveItem("Match");
                inventory.AddItem(0);
                break;
            }   

        }
    }

    public void NoMaterialsError()
    {

    }
}
