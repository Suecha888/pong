using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BackRoom : MonoBehaviourPunCallbacks
{
    public GameObject RoomPanel;
    public GameObject GameServerPanel;
    private RoomList roomList = new RoomList();     // 作成したルームのリスト

    // Start is called before the first frame update
    void Start()
    {
    }

    public void BackButtonClicksd()
    {
        // ルームから退出しマスターサーバーに戻る
        PhotonNetwork.LeaveRoom();
        roomList.Clear();
        GameServerPanel.SetActive(false);
        RoomPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
