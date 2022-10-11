using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Luncher : MonoBehaviourPunCallbacks
{
    [Tooltip("�P���[��������̍ő�l��")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;

    private string gameVersion = "1";

    private bool isConnecting;

    private bool switchFlg = false;
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Connect();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Connect()
    {
        // �ڑ����Ă����烉���_���ȃ��[���ɎQ��
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            // PhotonServerSettings�̐ݒ���e���g���ă}�X�^�[�T�[�o�[�֐ڑ�����
            isConnecting = PhotonNetwork.ConnectUsingSettings();
        }
    }

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster()
    {
        if(isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
        Debug.Log("suezaki/Luncher: OnConnectedToMaster() was called by PUN");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("suezaki/Luncher: OnDisconnected() was called by PUN with reason {0}",cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("suezaki/Luncher: OnJoinRandomFailed() was called by PUN No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("suezaki/Luncher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    
    #endregion
}
