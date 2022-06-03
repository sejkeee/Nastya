using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        if (NetworkManager.Singleton.IsClient)
        {
            var toZ = Input.GetAxis("Vertical");
            var toX = Input.GetAxis("Horizontal");
                
            if (NetworkManager.Singleton.LocalClient != null)
            {
                if (NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent(out Movement movement))
                {
                    movement.MoveServerRpc(toZ, toX);
                }
            }
        }
        
        
    }
}
