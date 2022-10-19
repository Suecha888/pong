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
    public AudioClip SE1;
    AudioSource audioSource;
    private RoomList roomList = new RoomList();     // �쐬�������[���̃��X�g

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickStart()
    {
        // Photon�T�[�o�[�ɐڑ����Ă��Ȃ�������
        if (!PhotonNetwork.IsConnected)
        {
            // ����炷
            audioSource.PlayOneShot(SE1);
            InputNamePanel.SetActive(true);
            TitlePanel.SetActive(false);
        }
        else
        {
            roomList.Clear();
            // ����炷
            audioSource.PlayOneShot(SE1);
            RoomPanel.SetActive(true);
            TitlePanel.SetActive(false);
        }
    }
}
