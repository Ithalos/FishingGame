using UnityEngine;
using System.Collections;
using System;

// Make sure some components cannot be accidentally deleted.
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour 
{
    Rigidbody player;
    public float speed;
    Animator anim;
    bool canFish;

    float timerToCatch;
    float timeBeforeBite;
    bool isFishing;

    public GameObject fishingZone;

    void Start()
    {
        // Fetching gameobject components to variables.
        player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        canFish = fishingZone.GetComponent<FishingZone>();
        timerToCatch = 0f;
        timeBeforeBite = 0f;
        isFishing = false;
    }

    void Update()
    {
        timerToCatch += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            FishCheck();
        }


        // FISHING TIMER
        if (timerToCatch > timeBeforeBite && isFishing)
        {
            Debug.Log("You have caught a fish!");
            Debug.Log("You have caught a fish!");
            Debug.Log("You have caught a fish!");
            Debug.Log("You have caught a fish!");
            Debug.Log("You have caught a fish!");
            Debug.Log("You have caught a fish!");

            isFishing = false;
        }
    }


    void FixedUpdate()
    {
        // Moving player.
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;
        player.MovePosition(player.position + moveDirection * speed * Time.deltaTime);

        
        // Set player rotation
        Quaternion rotation = transform.rotation;
        if (moveDirection.x != 0 || moveDirection.z != 0)
        {
            rotation.SetLookRotation(moveDirection);
        }
        transform.rotation = rotation;
        

        // Sets animation for walking if player is moving.
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }

    }


    void FishCheck()
    {
        canFish = fishingZone.GetComponent<FishingZone>().PlayerCanFish();

        if (canFish)
        {
            Fish();
            Debug.Log("You are fishing! :)");
        }
        else
        {
            Debug.Log("You cannot fish here, stupid!");
        }
    }

    void Fish()
    {
        timerToCatch = 0f;
        timeBeforeBite = 0f;
        System.Random random = new System.Random();
        timeBeforeBite = random.Next(10) + 5;

        Debug.Log(timeBeforeBite);
        isFishing = true;
    }
}
