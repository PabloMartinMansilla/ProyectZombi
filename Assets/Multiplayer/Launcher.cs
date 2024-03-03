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
        PhotonNetwork.JoinRandomOrCreateRoom();

    }

    public override void OnJoinedRoom()
    { 
        GameObject player = PhotonNetwork.Instantiate(Player.name, spawn.position, spawn.rotation);
        Debug.Log(player.name);
        player.tag = "Player";
    }
}
