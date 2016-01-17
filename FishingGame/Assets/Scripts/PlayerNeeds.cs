using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerNeeds : MonoBehaviour 
{
    public Image foodBar;
    public Image waterBar;
    public Image healthBar;

    public AudioClip eatSound;
    public AudioClip drinkSound;

    public float maxFood = 100f;
    public float maxWater = 50f;
    public float maxHealth = 100f;

    public float foodDecayRate = 0.03f;
    public float waterDecayRate = 0.03f;

    public float food;
    public float water;
    public float health;
    public float healthRegenRate = 0.15f;

    public FishingZone FishingZone;
    bool nearWater = false;

    public Inventory Inventory;
    bool hasFood = false;

    void Start()
    {
        food = maxFood;
        water = maxWater;
        health = maxHealth;
    }

    void FixedUpdate()
    {
        UpdateNeeds();
        UpdateNeedsUI();
    }

    void UpdateNeeds()
    {
        food -= foodDecayRate;
        water -= waterDecayRate;


        // Decay of health
        if (food < 0)
        {
            health -= 0.1f;
        }

        if (water < 0)
        {
            health -= 0.2f;
        }

        if (food < 0 && water < 0)
        {
            health -= 0.2f;
        }

        // Health regeneration
        if (food > 80 && water > 40)
        {
            health += healthRegenRate;

            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }

    void UpdateNeedsUI()
    {
        foodBar.fillAmount = food / maxFood;
        waterBar.fillAmount = water / maxWater;
        healthBar.fillAmount = health / maxHealth;
    }

    public void Drink()
    {
        nearWater = FishingZone.GetComponent<FishingZone>().PlayerCanFish();

        if (nearWater)
        {
            water += 10f;
            GetComponent<AudioSource>().PlayOneShot(drinkSound);

            if (water > maxWater)
            {
                water = maxWater;
            }
        }
    }

    public void Eat()
    {
        hasFood = Inventory.GetComponent<Inventory>().CheckForItemInInventoryByName("Cooked Salmon");

        if (hasFood)
        {
            GetComponent<AudioSource>().PlayOneShot(eatSound, 0.3f);
            Inventory.GetComponent<Inventory>().RemoveItem("Cooked Salmon");
            food += 20;

            if (food > maxFood)
            {
                food = maxFood;
            }
        }
    }
}
