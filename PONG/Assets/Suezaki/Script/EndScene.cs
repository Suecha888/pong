using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EndScene : MonoBehaviourPunCallbacks,IPunObservable
{
    private KeyCode SceneChangeKey;
    [SerializeField] GameObject winner;

    [SerializeField]
    private GameObject StartAnounce;
    [SerializeField]
    string winnername ="";
    string oldname = "";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroy.instance.GetComponent<SceneChange>().load = true;
        DontDestroy.instance.GetComponent<Event>().WinnerEvent.AddListener(winner.GetComponent<ShowWinner>().showWinner);
        // ���҂̕\��
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


        if (winnername != oldname)
        {
            Debug.Log("aaaaa :" + winnername);
            
            DontDestroy.instance.GetComponent<Event>().WinnerEvent.Invoke(winnername);
            oldname = winnername;
            winner.SetActive(true);
        }
        
        
        if (PhotonNetwork.IsMasterClient)
        {
            StartAnounce.transform.Find("press_button").gameObject.SetActive(true);
            StartAnounce.transform.Find("client").gameObject.SetActive(false);

            if (Input.GetKey(SceneChangeKey) && DontDestroy.instance.GetComponent<SceneChange>().load)
            {
                DontDestroy.instance.GetComponent<SceneChange>().load = false;
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
