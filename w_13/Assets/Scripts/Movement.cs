using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;


    private float speed = 10f;
    private float jumpSpeed = 130f;
    private float gravity = -9.81f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var toZ = Input.GetAxis("Vertical");
        var toX = Input.GetAxis("Horizontal");

        var velocity = (transform.forward * toZ + transform.right * toX) * speed * Time.deltaTime;
        
        if (controller.isGrounded)
        {
            velocity.y = 0f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y = jumpSpeed * Time.deltaTime;
            }
        }

        velocity.y += gravity * Time.deltaTime;
        //velocity.y *= Time.deltaTime;
        
        controller.Move(velocity);
    }
}
