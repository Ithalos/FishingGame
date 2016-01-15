using UnityEngine;
using System.Collections;

public class Crafting : MonoBehaviour
{
    public GameObject inventoryObject;
    Inventory inventory;

    public GameObject fireplacePrefab;

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
                inventory.AddItem(5);
                break;
            }   

        }
    }

    public void NoMaterialsError()
    {

    }

    public void PlaceFireplace()
    {
        for (int i = 0; i < inventory.slots.Count; i++)
        {
            if (inventory.slots[i].name == "Fireplace")
            {
                // Change location of where the campfire is put down remains to be done.
                inventory.RemoveItem("Fireplace");
                Instantiate(fireplacePrefab, new Vector3(100f, 3f, 61f), Quaternion.identity);

                break;
            }
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaceFireplace();
        }
    }
}
