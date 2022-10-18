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
        // ���r�[�ɎQ��
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
        // ���r�[�ɎQ��
        PhotonNetwork.JoinLobby();
    }

    public void BackClicked()
    {
        RoomPanel.SetActive(true);
        MatchmakingView.SetActive(false);
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
}
