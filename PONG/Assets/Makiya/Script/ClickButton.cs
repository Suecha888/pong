using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ClickButton : MonoBehaviourPunCallbacks
{
    public GameObject RoomPanel;
    //public GameObject CreateRoomPanel;
    public GameObject MatchmakingView;
    [SerializeField]
    private GameObject Luncher;

    public void Start()
    {
        // ロビーに参加
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoomClicked()
    {
        RoomPanel.SetActive(false);
        //CreateRoomPanel.SetActive(true);
    }

    public void JoinRandomRoomClicked()
    {
        //PhotonNetwork.JoinRandomRoom();
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
        //CreateRoomPanel.SetActive(false);
        MatchmakingView.SetActive(false);
    }

    // ランダムでルームに参加出来なかった時
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // ロビーに参加
        PhotonNetwork.JoinLobby();
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
