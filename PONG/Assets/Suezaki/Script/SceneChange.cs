using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;

public class SceneChange : MonoBehaviourPunCallbacks
{
    // �V�[���̃��X�g
    [SerializeField]
    List<string> scenes = new List<string>();
    // �V�[���̃C���f�b�N�X
    int index = 0;
    // �V�[���̍ő吔
    int max = 0;
    // �V�[�����ǂݍ��܂ꂽ�t���O
    public bool load = false;
    // �V�[���߂�t���O
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
    // �V�[���ؑ�
    public void ChangeScene()
    {
        // �}�X�^�[�N���C�A���g�ȊO�̓X���[
        if(!PhotonNetwork.IsMasterClient)
        {
            Debug.Log("PhotonNetwork: Trying to Load a level but we are not the master client");
            return;
        }

        // ���̃V�[���ɐؑ�
        index++;
        Debug.LogFormat("PhotonNetwork: Load scene {0}", scenes[index % max]);
        PhotonNetwork.LoadLevel(scenes[index % max]);
    }
    // ���[���ޏo
    public  void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    
    // �V�[�����ЂƂO�ɂ��ǂ�
    public void UpdateLeave()
    {
        if(!leave)
        {
            index--;
            leave = true;
        }
    }
    // �V�[���̃C���f�b�N�X���Z�b�g
    public void setIndex(int n)
    {
        index = n;
    }
    // �V�[���̃C���f�b�N�X���擾
    public int getIndex()
    {
        return index % max;
    }
    #region Photon Callbacks

    // �����[�g�v���C���[�����[���ɓ������Ƃ��ɌĂяo����܂��B���̃v���C���[�͂��łɃv���C���[���X�g�ɒǉ�����Ă��܂�
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player other)
    {
        Debug.LogFormat("OnPlayerEnteredRoom(){0}", other.NickName);

        if(PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);
        }
    }

    // ���[�J�����[�U�[/�N���C�A���g�����[�����o���Ƃ��ɌĂяo����A�Q�[���̃��W�b�N��������Ԃ��N���[���A�b�v�ł���悤�ɂ��܂�
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(scenes[index % max]);
        base.OnLeftRoom();
    }

    // �����[�g�v���C���[�����[���𗣂�邩�A��A�N�e�B�u�ɂȂ����Ƃ��ɌĂяo����܂��B
    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        DontDestroy.instance.GetComponent<SceneChange>().UpdateLeave();
        DontDestroy.instance.GetComponent<SceneChange>().LeaveRoom();
        Debug.LogFormat("OnPlayerLeftRoom() {0}", other.NickName);

        if (PhotonNetwork.IsMasterClient)
        {
            Debug.LogFormat("OnPlayerLeftRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient);

        }
    }
    #endregion
}
