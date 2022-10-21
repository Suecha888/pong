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

    public GameObject pointButton1;
    public GameObject pointButton2;
    public GameObject boundButton;
    public GameObject accelButton;
    public AudioClip SE1;
    AudioSource audioSource;
    bool se = false;

    // Start is called before the first frame update
    void Start()
    {
        // 接続待機の表示
        //StartAnounce.transform.Find("conect").gameObject.SetActive(true);

        // シーンチェンジのキーを取得
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
        // シーンチェンジフラグoff
        DontDestroy.instance.GetComponent<SceneChange>().load = false;
        audioSource = GetComponent<AudioSource>();
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

        // backボタンで戻った時
        if(PhotonNetwork.IsMasterClient && SceneChange.backroom)
        {
            connect = false;
            settingtext = true;
            StartAnounce.transform.Find("press_button").gameObject.SetActive(false);
            StartAnounce.transform.Find("client").gameObject.SetActive(false);
            pointButton1.SetActive(false);
            pointButton2.SetActive(false);
            boundButton.SetActive(false);
            accelButton.SetActive(false);
        }
        if(!PhotonNetwork.IsMasterClient && SceneChange.backroom2)
        {
            connect = false;
            settingtext = true;
            StartAnounce.transform.Find("press_button").gameObject.SetActive(false);
            StartAnounce.transform.Find("client").gameObject.SetActive(false);
            pointButton1.SetActive(false);
            pointButton2.SetActive(false);
            boundButton.SetActive(false);
            accelButton.SetActive(false);
        }
        
        // 接続したら表示を切り替える
        if (connect)
        {
            if (!settingtext)
            {
                StartAnounce.transform.Find("setting").gameObject.SetActive(true);
                //showmatchpoint.reset = true;
                //showreflectball.reset = true;
                //showballaccel.reset = true;
                // マスタークライアントだけにボタン表示
                if (PhotonNetwork.IsMasterClient)
                {
                    pointButton1.SetActive(true);
                    pointButton2.SetActive(true);
                    boundButton.SetActive(true);
                    accelButton.SetActive(true);
                }
                settingtext = true;
            }

            //StartAnounce.transform.Find("conect").gameObject.SetActive(false);
            // マスタークライアントはシーン切替ボタンの表示
            if (PhotonNetwork.IsMasterClient && ready)
            {
                if (se)
                {
                    // 音を鳴らす
                    audioSource.PlayOneShot(SE1);
                    se = false;
                }
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
        settingtext = false;
        se = true;
        showmatchpoint.reset = true;
        showreflectball.reset = true;
        showballaccel.reset = true;
    }
    
}