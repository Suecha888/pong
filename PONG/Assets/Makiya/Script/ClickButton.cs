using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ClickButton : MonoBehaviour
{
    public void JoinOnCreateRoomClicked()
    {
        // "Room"�Ƃ������O�̃��[���ɎQ������B�i���[�������݂��Ȃ���΍쐬���ĎQ������j
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public void CreateRoomClicked()
    {
        // "Room"�Ƃ������O�̃��[�����쐬����
        PhotonNetwork.CreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public void JoinRoomClicked()
    {
        // "Room"�Ƃ������O�̃��[���ɎQ������
        //PhotonNetwork.JoinRoom("Room");
    }

    public void BallClicked()
    {
        // �{�[���𔭎˂���
        Ball.flg = true;
    }
}
