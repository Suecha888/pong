using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StartScene : MonoBehaviour
{
    // シーン切替のキー
    private KeyCode SceneChangeKey;
    // ネットワークの設定
    [SerializeField]
    private GameObject Luncher;
    // 状態の表示メッセージ
    [SerializeField]
    private GameObject StartAnounce;
    // 接続したかどうか
    bool connect = false;
    // 人数がそろったかどうか
    bool ready = false;
    // setting テキストの表示
    bool settingtext = false;
    // Start is called before the first frame update
    void Start()
    {
        // 接続待機の表示
        //StartAnounce.transform.Find("conect").gameObject.SetActive(true);
        
        // シーンチェンジのキーを取得
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
        // シーンチェンジフラグoff
        DontDestroy.instance.GetComponent<SceneChange>().load = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(PhotonNetwork.PlayerList.Length == 2)
        {
            ready = true;
        }
        else
        {
            ready = false;
        }

        // マスタークライアントがキーを押してシーン切替
        if (PhotonNetwork.IsMasterClient && ready)
        {
            if (Input.GetKey(SceneChangeKey) && !DontDestroy.instance.GetComponent<SceneChange>().load)
            {
                DontDestroy.instance.GetComponent<SceneChange>().load = true;
                DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
            }
        }

        // 接続したら表示を切り替える
        if (connect)
        {
            if(!settingtext)
            {
                StartAnounce.transform.Find("setting").gameObject.SetActive(true);
                settingtext = true;
            }
            //StartAnounce.transform.Find("conect").gameObject.SetActive(false);
            // マスタークライアントはシーン切替ボタンの表示
            if (PhotonNetwork.IsMasterClient && ready)
            {
                StartAnounce.transform.Find("press_button").gameObject.SetActive(true);
                StartAnounce.transform.Find("client").gameObject.SetActive(false);

            }
            // クライアントはマスタークライアントを待つ表示
            else 
            {
                StartAnounce.transform.Find("press_button").gameObject.SetActive(false);
                StartAnounce.transform.Find("client").gameObject.SetActive(true);
            }
                
        }

        // サーバーに接続
        //if (Input.GetKey(KeyCode.C))
        //{
        //    this.Luncher.GetComponent<Luncher>().Connect();
        //    connect = true;
        //}

        
    }
    
    public void Setconnect()
    {
        connect = true;
    }
    
}