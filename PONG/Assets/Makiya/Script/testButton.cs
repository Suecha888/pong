using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class testButton : MonoBehaviourPunCallbacks
{
    public GameObject TitlePanel;
    public GameObject InputNamePanel;
    public GameObject RoomPanel;
    private RoomList roomList = new RoomList();     // 作成したルームのリスト

    public void ClickStart()
    {
        // Photonサーバーに接続していなかったら
        if (!PhotonNetwork.IsConnected)
        {
            TitlePanel.SetActive(false);
            InputNamePanel.SetActive(true);
        }
        else
        {
            roomList.Clear();
            TitlePanel.SetActive(false);
            RoomPanel.SetActive(true);
        }
    }

}
