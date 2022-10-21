using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class testButton : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Button createRoomButton = default;

    public GameObject TitlePanel;
    public GameObject InputNamePanel;
    public AudioClip SE1;
    AudioSource audioSource;
    private RoomList roomList = new RoomList();     // 作成したルームのリスト

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        createRoomButton.onClick.AddListener(ClickStart);
    }

    public void ClickStart()
    {
        // コルーチン開始
        StartCoroutine("SetPanel");
    }

    IEnumerator SetPanel()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);

        // 数秒停止
        yield return new WaitForSeconds(0.5f);

        // Photonサーバーに接続していなかったら
        if (!PhotonNetwork.IsConnected)
        {
            InputNamePanel.SetActive(true);
            TitlePanel.SetActive(false);
        }
        else
        {
            roomList.Clear();
            // 設定の初期化
            DontDestroy.instance.GetComponent<Setting>().ResetSetting();
            InputNamePanel.SetActive(true);
            TitlePanel.SetActive(false);
        }
    }
}
