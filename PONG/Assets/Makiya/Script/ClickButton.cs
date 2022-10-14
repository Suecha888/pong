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

    // �����_���Ń��[���ɎQ���o���Ȃ�������
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);

        Debug.Log("�����_���Q�����s");
    }

    // ���[����ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnLeftRoom()
    {
        Debug.Log("�}�X�^�[�T�[�o�[�ɐڑ�����");
    }

    public void ShowRoomListClicked()
    {
        RoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // ���r�[�ɎQ������
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
    //    // "Room"�Ƃ������O�̃��[���ɎQ������B�i���[�������݂��Ȃ���΍쐬���ĎQ������j
    //    PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    //}

    //public void CreateRoomClicked2()
    //{
    //    // "Room"�Ƃ������O�̃��[�����쐬����
    //    PhotonNetwork.CreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    //}

}
