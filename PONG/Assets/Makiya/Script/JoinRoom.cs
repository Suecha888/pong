using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class JoinRoom : MonoBehaviourPunCallbacks
{
    public GameObject InputNamePanel;
    public GameObject RoomPanel;

    public void JoinButtonClicked()
    {
        // PhotonServerSettingsの設定内容を使ってマスターサーバーへ接続する
        PhotonNetwork.ConnectUsingSettings();
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        //Debug.Log("マスターサーバーに接続成功");
        // パネルの表示/非表示
        InputNamePanel.SetActive(false);
        RoomPanel.SetActive(true);
    }
}
