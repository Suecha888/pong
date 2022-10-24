using System.Collections;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public GameObject InputNamePanel;
    public GameObject RoomPanel;
    public AudioClip SE1;
    AudioSource audioSource;
    public Button JoinRoomButton;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // ボタンを押せなくする
        JoinRoomButton.interactable = false;
        JoinRoomButton.onClick.AddListener(JoinButtonClicked);
    }

    public void JoinButtonClicked()
    {
        // ルーム作成ボタンを押せなくする
        JoinRoomButton.interactable = false;
        // Photonサーバーに接続していなかったら
        if (!PhotonNetwork.IsConnected)
        {
            // 音を鳴らす
            audioSource.PlayOneShot(SE1);
            // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            // コルーチン開始
            StartCoroutine("SetPanel");
        }
    }

    IEnumerator SetPanel()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);

        // 数秒停止
        yield return new WaitForSeconds(0.5f);

        // ロビーに参加
        PhotonNetwork.JoinLobby();
        InputNamePanel.SetActive(false);
        RoomPanel.SetActive(true);
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        Debug.Log("マスターサーバーに接続");
        // ロビーに参加
        PhotonNetwork.JoinLobby();
        // パネルの表示/非表示
        InputNamePanel.SetActive(false);
        RoomPanel.SetActive(true);
    }
}
