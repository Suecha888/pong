using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class SceneChange : MonoBehaviourPunCallbacks
{
    [SerializeField]
    List<string> scenes = new List<string>();

    int index = 0;
    int max = 0;
    public bool load = false;
    public bool leave = false;
    // Start is called before the first frame update
    void Start()
    {
        max = scenes.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            Debug.Log("PhotonNetwork: Trying to Load a level but we are not the master client");
            return;
        }
        index++;
        Debug.LogFormat("PhotonNetwork: Load scene {0}", scenes[index % max]);
        PhotonNetwork.LoadLevel(scenes[index % max]);
        //SceneManager.LoadScene(scenes[++index % max]);
    }

    public  void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(scenes[index % max]);
        base.OnLeftRoom();
    }
    public void UpdateLeave()
    {
        if(!leave)
        {
            index--;
            leave = true;
        }
    }
    public void setIndex(int n)
    {
        index = n;
    }
    public int getIndex()
    {
        return index;
    }
    #region Photon Callbacks

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom(){0}", other.NickName);

        if(PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
        }
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName); 


        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

            
        }
    }
    #endregion
}
