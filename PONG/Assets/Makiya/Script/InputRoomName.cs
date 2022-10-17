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

    // プレイヤーの名前設定
    public void SetName()
    {
        // ルーム名を設定
        RoomName = inputname.text;
        //Debug.Log("ルーム名：" + RoomName);

        // Joinボタンの表示
        JoinButton.SetActive(true);
    }

    public void JoinButtonClicked()
    {
        // ロビーに参加する
        PhotonNetwork.JoinLobby();
        // ルームを作成する
        //PhotonNetwork.CreateRoom(RoomName, new RoomOptions(), TypedLobby.Default);

        // パネルの表示/非表示
        CreateRoomPanel.SetActive(false);
        MatchmakingView.SetActive(true);
    }

    public override void OnJoinedLobby()
    {
        // ルームを作成する
        //var roomOptions = new RoomOptions();
        //roomOptions.MaxPlayers = 2;
        //PhotonNetwork.CreateRoom(RoomName, roomOptions, TypedLobby.Default);
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        //Debug.Log("ゲームサーバーに接続成功");
        // シーン切り替え
        //SceneManager.LoadScene("SampleScene");
    }
}
