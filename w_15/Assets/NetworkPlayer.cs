using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
    
    private void Start()
    {
        GetComponent<Movement>().enabled = GetComponent<NetworkObject>().IsLocalPlayer;
    }
}
