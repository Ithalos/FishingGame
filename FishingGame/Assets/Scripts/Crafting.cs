using UnityEngine;
using System.Collections;

public class Crafting : MonoBehaviour
{
    public GameObject inventoryObject;
    Inventory inventory;

    public GameObject fireplacePrefab;
    Fireplace fireplaceScript;
    public GameObject player;

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
                inventory.RemoveItem("Fireplace");
                GameObject fireplace = GameObject.Instantiate<GameObject>(fireplacePrefab);
                fireplaceScript = fireplace.GetComponent<Fireplace>();

                Vector3 location = player.GetComponent<Transform>().position;
                Vector3 fireplaceOffset = new Vector3(0f, 0.25f, 0f);
                fireplace.transform.position = location + fireplaceOffset;

                // fireplace.transform.position = new Vector3(100f, 3f, 61f);
                break;
            }
        }
    }

    public void CookFish()
    {
        if (fireplaceScript != null && fireplaceScript.playerNearFireplace)
        {
            for (int i = 0; i < inventory.slots.Count; i++)
            {
                if (inventory.slots[i].name == "Raw Salmon")
                {
                    inventory.RemoveItem("Raw Salmon");
                    inventory.AddItem(7);
                    break;
                }
            }
        }
    }
}
