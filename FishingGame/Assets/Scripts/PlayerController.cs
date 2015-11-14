using UnityEngine;
using System.Collections;

// Make sure some components cannot be accidentally deleted.
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]


public class PlayerController : MonoBehaviour 
{
    Rigidbody player;
    public float speed;

    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        moveDirection = Camera.main.transform.TransformDirection(moveDirection);
        moveDirection.y = 0;


        player.MovePosition(player.position + moveDirection * speed * Time.deltaTime);

        var rotation = transform.rotation;
        rotation.SetLookRotation(moveDirection);
        transform.rotation = rotation;
    }
}
