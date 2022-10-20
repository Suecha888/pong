using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BackRoom : MonoBehaviourPunCallbacks
{
    public GameObject SettingPanel;
    public GameObject MatchmakingView;
    private RoomList roomList = new RoomList();     // 作成したルームのリスト
    public AudioClip SE1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
    }

    public void BackButtonClicksd()
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

        roomList.Clear();
        if(PhotonNetwork.IsMasterClient)
        {
            SceneChange.backroom = true;
        }
        else
        {
            SceneChange.backroom2 = true;
        }
        SettingPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // 設定の初期化
        DontDestroy.instance.GetComponent<Setting>().ResetSetting();
        // ルームから退出しマスターサーバーに戻る
        PhotonNetwork.LeaveRoom();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        roomList.Clear();
        if (PhotonNetwork.IsMasterClient)
        {
            SceneChange.backroom = true;
        }
        else
        {
            SceneChange.backroom2 = true;
        }
        SettingPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // 設定の初期化
        DontDestroy.instance.GetComponent<Setting>().ResetSetting();
        // ルームから退出しマスターサーバーに戻る
        PhotonNetwork.LeaveRoom();
    }
}
