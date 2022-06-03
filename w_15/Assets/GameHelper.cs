using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class GameHelper : MonoBehaviour
{
    public InputField Input;
    public Text TextBlock;

    private void Update()
    {
        if (NetworkManager.Singleton.IsClient && NetworkManager.Singleton.LocalClient != null)
        {
            if (NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent(out PlayerHelper hero))
            {
                hero.SendClientRpc(TextBlock.text);
            }
        }
    }
    
    public void Send()
    {
        if (NetworkManager.Singleton.IsClient && NetworkManager.Singleton.LocalClient != null)
        {
            if (NetworkManager.Singleton.LocalClient.PlayerObject.TryGetComponent(out PlayerHelper hero))
            {
                hero.SendServerRpc(Input.text);
                hero.SendClientRpc(TextBlock.text);
            }
        }

        Input.text = "";
    }
}
