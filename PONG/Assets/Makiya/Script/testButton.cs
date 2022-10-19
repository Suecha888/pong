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
    private RoomList roomList = new RoomList();     // 作成したルームのリスト

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ClickStart()
    {
        // Photonサーバーに接続していなかったら
        if (!PhotonNetwork.IsConnected)
        {
            // 音を鳴らす
            audioSource.PlayOneShot(SE1);
            InputNamePanel.SetActive(true);
            TitlePanel.SetActive(false);
        }
        else
        {
            roomList.Clear();
            // 音を鳴らす
            audioSource.PlayOneShot(SE1);
            RoomPanel.SetActive(true);
            TitlePanel.SetActive(false);
        }
    }
}
