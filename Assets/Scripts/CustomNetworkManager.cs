using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

public class CustomNetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        Debug.Log($"Server started ({DateTime.Now}).");
    }

    public override void OnStopServer()
    {
        Debug.Log($"Server stopped ({DateTime.Now}).");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log($"Client connected with the address '{conn.address}' and ID '{conn.connectionId}'.");

        base.OnClientConnect(conn);
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log($"Client disconnected with the address '{conn.address}' and ID '{conn.connectionId}'.");

        base.OnClientDisconnect(conn);
    }
}
