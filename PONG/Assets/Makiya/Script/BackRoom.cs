using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class BackRoom : MonoBehaviourPunCallbacks
{
    public GameObject SettingPanel;
    public GameObject MatchmakingView;
    private RoomList roomList = new RoomList();     // �쐬�������[���̃��X�g
    public AudioClip SE1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
    }

    public void BackButtonClicksd()
    {
        // �R���[�`���J�n
        StartCoroutine("SetPanel");
    }

    IEnumerator SetPanel()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);

        // ���b��~
        yield return new WaitForSeconds(0.5f);

        roomList.Clear();
        if(PhotonNetwork.IsMasterClient)
        {
            SceneChange.backroom = true;
        }
        else
        {
            SceneChange.backroom2 = true;
        }
        SettingPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // �ݒ�̏�����
        DontDestroy.instance.GetComponent<Setting>().ResetSetting();
        // ���[������ޏo���}�X�^�[�T�[�o�[�ɖ߂�
        PhotonNetwork.LeaveRoom();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        roomList.Clear();
        if (PhotonNetwork.IsMasterClient)
        {
            SceneChange.backroom = true;
        }
        else
        {
            SceneChange.backroom2 = true;
        }
        SettingPanel.SetActive(false);
        MatchmakingView.SetActive(true);
        // �ݒ�̏�����
        DontDestroy.instance.GetComponent<Setting>().ResetSetting();
        // ���[������ޏo���}�X�^�[�T�[�o�[�ɖ߂�
        PhotonNetwork.LeaveRoom();
    }
}
