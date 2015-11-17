using UnityEngine;
using System.Collections;

// Make sure some components cannot be accidentally deleted.
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour 
{
    Rigidbody player;
    public float speed;
    Animator anim;

    void Start()
    {
        // Fetching gameobject components to variables.
        player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

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
}
