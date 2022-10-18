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
    private RoomList roomList = new RoomList();     // �쐬�������[���̃��X�g

    public void ClickStart()
    {
        // Photon�T�[�o�[�ɐڑ����Ă��Ȃ�������
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
