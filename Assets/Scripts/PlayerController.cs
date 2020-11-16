using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [SyncVar(hook = nameof(OnTestCountChanged))]
    int testCount = 0;

    public float speed = 0.1f;

    private void Update()
    {
        HandleMovement();

        if(isLocalPlayer && Input.GetKeyDown(KeyCode.T))
        {
            //run on client
            Debug.Log($"Sending a 'Test' command.");
            Test();
        }

        if(isServer && transform.position.y > 5.5f)
        {
            //never spam commands through network lmao
            TooHigh();
        }
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

    public override void OnStartServer()
    {
        Debug.Log($"Player has been spawned on the server.");
    }

    [Command]
    private void Test()
    {
        //run on server
        Debug.Log($"Received a 'Test' command from client.");
        testCount ++;
        ReceivedTest();
    }

    [TargetRpc]
    private void ReceivedTest()
    {
        //run on client
        Debug.Log($"Received a 'Test' command from the server.");
    }

    [ClientRpc]
    private void TooHigh()
    {
        //run on client
        Debug.Log($"Too high!");
    }

    void OnTestCountChanged(int oldCount, int newCount)
    {
        Debug.Log($"Incremented Tests by one ({oldCount} -> {newCount}).");
    }
}
