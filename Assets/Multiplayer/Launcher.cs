using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{

    public PhotonView Player;
    public Transform spawn;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

    }


    public override void OnConnectedToMaster()
    {
        Debug.Log("conectado");
        PhotonNetwork.JoinRandomOrCreateRoom();

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("unido");
        PhotonNetwork.Instantiate(Player.name, spawn.position, spawn.rotation);
    }
}
