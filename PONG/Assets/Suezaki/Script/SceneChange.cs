using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class SceneChange : MonoBehaviourPunCallbacks
{
    // シーンのリスト
    [SerializeField]
    List<string> scenes = new List<string>();

    [SerializeField]
    List<string> offlinescenes = new List<string>();
    int offlineindex = 0;
    int offlinemax = 0;

    // シーンのインデックス
    int index = 0;
    // シーンの最大数
    int max = 0;
    // シーンが読み込まれたフラグ
    public bool load = false;
    // シーン戻るフラグ
    public bool leave = false;
    public static bool backroom = false;
    public static bool backroom2 = false;
    public static bool gameScene = false;
    public static bool endScene = false;

    // Start is called before the first frame update
    void Start()
    {
        max = scenes.Count;
        offlinemax = offlinescenes.Count;
    }

    public void OfflineSceneChange()
    {
        offlineindex++;
        SceneManager.LoadScene(offlinescenes[offlineindex % offlinemax]);
    }
    public void PlayOfflineGame()
    {
        SceneManager.LoadScene(offlinescenes[0]);
    }
    public void EndOfflineGame()
    {
        SceneManager.LoadScene(scenes[0]);
    }
    // シーン切替
    public void ChangeScene()
    {
        // マスタークライアント以外はスルー
        if(!PhotonNetwork.IsMasterClient)
        {
            Debug.Log("PhotonNetwork: Trying to Load a level but we are not the master client");
            return;
        }

        // 次のシーンに切替
        index++;
        Debug.LogFormat("PhotonNetwork: Load scene {0}", scenes[index % max]);
        PhotonNetwork.LoadLevel(scenes[index % max]);
    }
    // ルーム退出
    public  void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    
    // シーンをひとつ前にもどす
    public void UpdateLeave()
    {
        if(!leave)
        {
            index--;
            leave = true;
        }
    }
    // シーンのインデックスをセット
    public void setIndex(int n)
    {
        index = n;
    }
    // シーンのインデックスを取得
    public int getIndex()
    {
        return index % max;
    }
    #region Photon Callbacks

    // リモートプレイヤーがルームに入ったときに呼び出されます。このプレイヤーはすでにプレイヤーリストに追加されています
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom(){0}", other.NickName);

        if(PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
        }
    }

    // ローカルユーザー/クライアントがルームを出たときに呼び出され、ゲームのロジックが内部状態をクリーンアップできるようにします
    public override void OnLeftRoom()
    {
        if (gameScene || endScene)
        {
            gameScene = false;
            endScene = false;
            index = 0;
            PhotonNetwork.LoadLevel(scenes[index]);
            base.OnLeftRoom();
        }
    }

    // リモートプレイヤーがルームを離れるか、非アクティブになったときに呼び出されます。
    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        if (gameScene || endScene)
        {
            DontDestroy.instance.GetComponent<SceneChange>().UpdateLeave();
            DontDestroy.instance.GetComponent<SceneChange>().LeaveRoom();
            Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName);

            if (PhotonNetwork.IsMasterClient)
            {
                Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

            }
        }
    }
    #endregion
}
