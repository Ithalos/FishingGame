using UnityEngine;
using System.Collections;

public class Fireplace : MonoBehaviour 
{
    public bool playerNearFireplace = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Player")
        {
            playerNearFireplace = true;
            Debug.Log("Player is near fireplace. Cooking available.");
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.name == "Player")
        {
            playerNearFireplace = false;
            Debug.Log("Player is NOT near fireplace.");
        }
    }
}
