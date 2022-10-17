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

    //private RoomList roomList = new RoomList();     // �쐬�������[���̃��X�g

    public void Start()
    {
        // ���r�[�ɎQ��
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoomClicked()
    {
        RoomPanel.SetActive(false);
        CreateRoomPanel.SetActive(true);
    }

    public void JoinRandomRoomClicked()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void ShowRoomListClicked()
    {
        RoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // ���r�[�ɎQ��
        PhotonNetwork.JoinLobby();
    }

    public void BackClicked()
    {
        RoomPanel.SetActive(true);
        CreateRoomPanel.SetActive(false);
        MatchmakingView.SetActive(false);
    }

    // �����_���Ń��[���ɎQ���o���Ȃ�������
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // ���r�[�ɎQ��
        PhotonNetwork.JoinLobby();
    }

    // �}�X�^�[�T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnConnectedToMaster()
    {
        Debug.Log("�}�X�^�[�T�[�o�[�ɐڑ�����");
        // ���r�[�ɎQ��
        PhotonNetwork.JoinLobby();
    }

    // ���[������ޏo�������ɌĂ΂��R�[���o�b�N
    public override void OnLeftRoom()
    {
        Debug.Log("���[����ޏo");
    }

    // �}�X�^�[�T�[�o�[�̃��r�[�ɓ��鎞�ɌĂ΂��R�[���o�b�N
    public override void OnJoinedLobby()
    {
        Debug.Log("���r�[�ɐڑ�����");
    }

    // �}�X�^�[�T�[�o�[�̃��r�[�ɂ���ԂɃ��[�����X�g���X�V���邽�߂ɌĂ΂��
    //public override void OnRoomListUpdate(List<RoomInfo> changedRoomList)
    //{
    //    roomList.Update(changedRoomList);
    //    foreach (var roomInfo in roomList)
    //    {
    //        Debug.Log("RoomInfo���F" + roomInfo);
    //    }
    //}
}
