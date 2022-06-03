using Unity.Netcode;
using UnityEngine;
using NetworkBehaviour = Unity.Netcode.NetworkBehaviour;


public class PlayerHelper : NetworkBehaviour
{
    [SerializeField] private GameHelper _gameHelper;

    private void Start()
    {
        _gameHelper = GameObject.FindObjectOfType<GameHelper>();
    }
    
    [ServerRpc]
    public void SendServerRpc(string message)
    {
        _gameHelper.TextBlock.text += $"\n {System.Environment.MachineName}: {message}";
    }

    [ClientRpc]
    public void SendClientRpc(string message)
    {
        _gameHelper.TextBlock.text = message;
    }
}
