using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 0.1f;

    private void Update()
    {
        HandleMovement();
    }

    public void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(inputHorizontal * speed, inputVertical * speed, 0);

            transform.position = transform.position + movement;
        }
    }
}
