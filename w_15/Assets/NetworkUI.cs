using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUI : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private Button StartHost;
    [SerializeField] private Button StartServer;
    [SerializeField] private Button StartClient;

    //private NetworkManager networkManager;

    private void Awake()
    {
        //networkManager = GetComponent<NetworkManager>();

        StartHost.onClick.AddListener(StartHostClick);
        StartServer.onClick.AddListener(StartServerClick);
        StartClient.onClick.AddListener(StartClientClick);
    }

    public void StartHostClick()
    {
        NetworkManager.Singleton.StartHost();
        Panel.SetActive(false);
    }
    
    public void StartServerClick()
    {
        NetworkManager.Singleton.StartServer();
        Panel.SetActive(false);
    }
    
    public void StartClientClick()
    {
        NetworkManager.Singleton.StartClient();
        Panel.SetActive(false);
    }
}
