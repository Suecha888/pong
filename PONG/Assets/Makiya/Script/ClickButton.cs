using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public void JoinOnCreateRoomClicked()
    {
        // "Room"という名前のルームに参加する。（ルームが存在しなければ作成して参加する）
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public void CreateRoomClicked()
    {
        // "Room"という名前のルームを作成する
        PhotonNetwork.CreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public void JoinRoomClicked()
    {
        // "Room"という名前のルームに参加する
        //PhotonNetwork.JoinRoom("Room");
    }

    public void BallClicked()
    {
        // ボールを発射する
        Ball.flg = true;
    }
}
