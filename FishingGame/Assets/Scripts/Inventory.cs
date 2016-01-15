using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour 
{
    GameObject inventoryPanel;
    GameObject slotPanel;

    ItemDatabase database;

    public GameObject inventorySlot;
    public GameObject inventoryItem;

    int slotAmount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    void Start()
    {
        database = GetComponent<ItemDatabase>();

        slotAmount = 16;
        inventoryPanel = GameObject.Find("Inventory Panel");
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;

        for (int i = 0; i < slotAmount; i++)
        {
            items.Add(new Item());
            slots.Add(Instantiate(inventorySlot));
            slots[i].transform.SetParent(slotPanel.transform);
            //slots[i].name = "Slot " + i;
        }

        AddItem(3);
        AddItem(4);

        Debug.Log(items.Count);
    }


    // TESTING ONLY
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateInventory("Match");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AddItem(3);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            AddItem(4);
        }

    }
    // TESTING ONLY END

    public void AddItem(int id)
    {
        Item itemToAdd = database.FetchItemByID(id);
        if (itemToAdd.Stackable && CheckForItemInInventory(itemToAdd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }

        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1)
                {
                    items[i] = itemToAdd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.localPosition = Vector2.zero;
                    itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                    itemObj.name = itemToAdd.Title;
                    // slots[i].name = "Slot " + i + " (" + itemToAdd.Title + ")";
                    slots[i].name = itemToAdd.Title;
                    Debug.Log(itemObj.transform.parent.name);
                    break;
                }
            }
        }
    }

    public bool CheckForItemInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
            {
                return true;
            }
        }

        return false;
    }

    public void UpdateInventory(string itemToRemove)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].name == itemToRemove)
            {

                GameObject inventoryChild = slots[i].transform.FindChild(itemToRemove).gameObject;
                Destroy(inventoryChild);

                // items[i].ID = -1;
                slots[i].name = "Empty";

                for (int a = 0; a < 10; a++)
                {
                    Debug.Log(items[a].ID);
                }

                break;


            }
        }
    }
}
