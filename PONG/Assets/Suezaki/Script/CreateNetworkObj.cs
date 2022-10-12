using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CreateNetworkObj : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.InstantiateRoomObject("ball", new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            PhotonNetwork.InstantiateRoomObject("pressbutton", new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            PhotonNetwork.InstantiateRoomObject("score", new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            PhotonNetwork.InstantiateRoomObject("gamescene", new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);

            PhotonNetwork.Instantiate("Player1", new Vector3(-8.5f, 0.0f, 0.0f), Quaternion.identity);
        }
        else
            PhotonNetwork.Instantiate("Player1", new Vector3(8.5f, 0.0f, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
