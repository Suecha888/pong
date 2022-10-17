using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class InputRoomName : MonoBehaviourPunCallbacks
{
    public TMP_InputField inputname;
    public GameObject JoinButton;
    private string RoomName;

    public GameObject CreateRoomPanel;
    public GameObject MatchmakingView;

    // �v���C���[�̖��O�ݒ�
    public void SetName()
    {
        // ���[������ݒ�
        RoomName = inputname.text;
        //Debug.Log("���[�����F" + RoomName);

        // Join�{�^���̕\��
        JoinButton.SetActive(true);
    }

    public void JoinButtonClicked()
    {
        // ���r�[�ɎQ������
        PhotonNetwork.JoinLobby();
        // ���[�����쐬����
        //PhotonNetwork.CreateRoom(RoomName, new RoomOptions(), TypedLobby.Default);

        // �p�l���̕\��/��\��
        CreateRoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);
    }

    public override void OnJoinedLobby()
    {
        // ���[�����쐬����
        //var roomOptions = new RoomOptions();
        //roomOptions.MaxPlayers = 2;
        //PhotonNetwork.CreateRoom(RoomName, roomOptions, TypedLobby.Default);
    }

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        //Debug.Log("�Q�[���T�[�o�[�ɐڑ�����");
        // �V�[���؂�ւ�
        //SceneManager.LoadScene("SampleScene");
    }
}
