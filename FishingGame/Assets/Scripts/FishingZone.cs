using UnityEngine;
using System.Collections;

public class FishingZone : MonoBehaviour 
{
    bool playerCanFish = false;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You have entered a fishing zone.");
        playerCanFish = true;
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("You have left a fishing zone.");
        playerCanFish = false;
    }

    public bool PlayerCanFish()
    {
        return playerCanFish;
    }
}