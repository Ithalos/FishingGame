using UnityEngine;
using System.Collections;

public class CraftingMenu : MonoBehaviour 
{
    public GameObject craftingUI;
    bool craftingMenuOpen;

    void Start()
    {
        craftingUI.SetActive(false);
        craftingMenuOpen = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Crafting"))
        {
            ToggleCraftingMenu();
        }
    }

    void ToggleCraftingMenu()
    {
        craftingMenuOpen = !craftingMenuOpen;


        if (craftingMenuOpen)
        {
            craftingUI.SetActive(true);
        }
        if (!craftingMenuOpen)
        {
            craftingUI.SetActive(false);
        }
    }
}
