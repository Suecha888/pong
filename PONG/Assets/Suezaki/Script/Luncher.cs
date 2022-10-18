using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Luncher : MonoBehaviourPunCallbacks
{
    [Tooltip("１ルーム当たりの最大人数")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    private string gameVersion = "1";

    private bool isConnecting;

    private bool switchFlg = false;
    private void Awake()
    {
        // MasterClient以外のClientがシーンの切り替えを、MasterClientのシーンの切り替えに同期
        PhotonNetwork.AutomaticallySyncScene = true;
        // PhotonNetworkがパケットを、1秒に何度送信するか
        PhotonNetwork.SendRate = 120;
        // OnPhotonSerializeがPhotonViewに、1秒何度呼ばれるか
        // PhotonNetwork.sendRateと関連させて、この値を決めてください。
        PhotonNetwork.SerializationRate = 120;
    }
   

    // マスターサーバーに接続してルームに入る
    public void Connect()
    {
        // 接続していたらランダムなルームに参加
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
            isConnecting = PhotonNetwork.ConnectUsingSettings();
        }
    }

    #region MonoBehaviourPunCallbacks Callbacks

    // クライアントがMaster Serverに接続されていて、マッチメイキングやその他のタスクを行う準備が整ったときに呼び出されます。
    public override void OnConnectedToMaster()
    {
        if(isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
        Debug.Log("suezaki/Luncher: OnConnectedToMaster() was called by PUN");
    }
    // Photonサーバーから切断した後に呼び出されます。
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("suezaki/Luncher: OnDisconnected() was called by PUN with reason {0}",cause);
    }
    // 前回のOpJoinRandom呼び出しがサーバーで失敗したときに呼び出されます。
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("suezaki/Luncher: OnJoinRandomFailed() was called by PUN No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }
    // このクライアントがルームを作成したか参加したかに関係なく、LoadBalancingClientがルームに入ったときに呼び出されます。
    public override void OnJoinedRoom()
    {
        Debug.Log("suezaki/Luncher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
    }
    #endregion
}
