using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BackRoom : MonoBehaviour
{
    public GameObject RoomPanel;
    public GameObject GameServerPanel;

    public void BackButtonClicksd()
    {
        // ルームから退出しマスターサーバーに戻る
        PhotonNetwork.LeaveRoom();
        GameServerPanel.SetActive(false);
        RoomPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
