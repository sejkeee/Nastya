using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Movement : NetworkBehaviour
{
    [SerializeField] private CharacterController controller;


    private float speed = 10f;
    private float jumpSpeed = 1000f;
    private float gravity = -9.81f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    [ServerRpc]
    public void MoveServerRpc(float toZ, float toX)
    {
        var velocity = (transform.forward * toZ + transform.right * toX) * speed * Time.deltaTime;

        controller.Move(velocity);
    }
}
