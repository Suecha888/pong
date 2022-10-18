using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BackRoom : MonoBehaviourPunCallbacks
{
    public GameObject RoomPanel;
    public GameObject GameServerPanel;
    private RoomList roomList = new RoomList();     // �쐬�������[���̃��X�g

    public void BackButtonClicksd()
    {
        // ���[������ޏo���}�X�^�[�T�[�o�[�ɖ߂�
        PhotonNetwork.LeaveRoom();
        roomList.Clear();
        GameServerPanel.SetActive(false);
        RoomPanel.SetActive(true);
    }

}
