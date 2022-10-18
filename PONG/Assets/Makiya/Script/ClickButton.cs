using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ClickButton : MonoBehaviourPunCallbacks
{
    public GameObject RoomPanel;
    public GameObject MatchmakingView;

    public void Start()
    {
        // ロビーに参加
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoomClicked()
    {
        RoomPanel.SetActive(false);
    }

    public void ShowRoomListClicked()
    {
        RoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // ロビーに参加
        PhotonNetwork.JoinLobby();
    }

    public void BackClicked()
    {
        RoomPanel.SetActive(true);
        MatchmakingView.SetActive(false);
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        Debug.Log("マスターサーバーに接続成功");
        // ロビーに参加
        PhotonNetwork.JoinLobby();
    }

    // ルームから退出した時に呼ばれるコールバック
    public override void OnLeftRoom()
    {
        Debug.Log("ルームを退出");
    }

    // マスターサーバーのロビーに入る時に呼ばれるコールバック
    public override void OnJoinedLobby()
    {
        Debug.Log("ロビーに接続成功");
    }
}
