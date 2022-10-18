using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EndScene : MonoBehaviourPunCallbacks,IPunObservable
{
    // シーンを切り替えるキー
    private KeyCode SceneChangeKey;
    // 勝者表示オブジェクト
    [SerializeField] GameObject winner;
    // ボタン案内表示
    [SerializeField]
    private GameObject StartAnounce;
    // 勝者名
    [SerializeField]
    string winnername ="";
    string oldname = "";

    // Start is called before the first frame update
    void Start()
    {
        DontDestroy.instance.GetComponent<SceneChange>().load = false;
        DontDestroy.instance.GetComponent<Event>().WinnerEvent.AddListener(winner.GetComponent<ShowWinner>().showWinner);
        // 勝者の表示
        if (PhotonNetwork.IsMasterClient)
        {
            DontDestroy.instance.GetComponent<Event>().WinnerEvent.Invoke(DontDestroy.instance.GetComponent<Data>().winner.name);
            winnername = DontDestroy.instance.GetComponent<Data>().winner.name;
        }
        else
        {
            winner.SetActive(false);
        }
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
    }

    // Update is called once per frame
    void Update()
    {

        if (PhotonNetwork.IsMasterClient)
        {
            winnername = DontDestroy.instance.GetComponent<Data>().winner.name;
        }

        // 名前表示
        if (winnername != oldname)
        {
            DontDestroy.instance.GetComponent<Event>().WinnerEvent.Invoke(winnername);
            oldname = winnername;
            winner.SetActive(true);
        }
        
        
        if (PhotonNetwork.IsMasterClient)
        {
            StartAnounce.transform.Find("press_button").gameObject.SetActive(true);
            StartAnounce.transform.Find("client").gameObject.SetActive(false);
            // マスタークライアントのみシーン遷移可能
            if (Input.GetKey(SceneChangeKey) && !DontDestroy.instance.GetComponent<SceneChange>().load)
            {
                DontDestroy.instance.GetComponent<SceneChange>().load = true;
                DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
            }
        }
        else
        {
            StartAnounce.transform.Find("press_button").gameObject.SetActive(false);
            StartAnounce.transform.Find("client").gameObject.SetActive(true);
        }
        
        
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(winnername);
        }
        else
        {
            winnername = (string)stream.ReceiveNext();
        }
    }
}
