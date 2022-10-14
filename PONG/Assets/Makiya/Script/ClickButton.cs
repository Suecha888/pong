using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ClickButton : MonoBehaviourPunCallbacks
{
    public GameObject RoomPanel;
    public GameObject CreateRoomPanel;
    public GameObject MatchmakingView;

    public void CreateRoomClicked()
    {
        RoomPanel.SetActive(false);
        CreateRoomPanel.SetActive(true);
    }

    public void JoinRandomRoomClicked()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    // ランダムでルームに参加出来なかった時
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);

        Debug.Log("ランダム参加失敗");
    }

    // ルームを退出した時に呼ばれるコールバック
    public override void OnLeftRoom()
    {
        Debug.Log("マスターサーバーに接続成功");
    }

    public void ShowRoomListClicked()
    {
        RoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // ロビーに参加する
        PhotonNetwork.JoinLobby();
    }

    public void BackClicked()
    {
        RoomPanel.SetActive(true);
        CreateRoomPanel.SetActive(false);
        MatchmakingView.SetActive(false);
    }

    //public void JoinOnCreateRoomClicked()
    //{
    //    // "Room"という名前のルームに参加する。（ルームが存在しなければ作成して参加する）
    //    PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    //}

    //public void CreateRoomClicked2()
    //{
    //    // "Room"という名前のルームを作成する
    //    PhotonNetwork.CreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    //}

}
