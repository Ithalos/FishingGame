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
        player = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;


        player.MovePosition(player.position + moveDirection * speed * Time.deltaTime);

        Quaternion rotation = transform.rotation;
        rotation.SetLookRotation(moveDirection);
        transform.rotation = rotation;

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
