using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StartScene : MonoBehaviour
{
    // �V�[���ؑւ̃L�[
    private KeyCode SceneChangeKey;
    // �l�b�g���[�N�̐ݒ�
    [SerializeField]
    private GameObject Luncher;
    // ��Ԃ̕\�����b�Z�[�W
    [SerializeField]
    private GameObject StartAnounce;
    // �ڑ��������ǂ���
    bool connect = false;
    // �l��������������ǂ���
    bool ready = false;
    // setting �e�L�X�g�̕\��
    bool settingtext = false;
    // Start is called before the first frame update
    void Start()
    {
        // �ڑ��ҋ@�̕\��
        //StartAnounce.transform.Find("conect").gameObject.SetActive(true);
        
        // �V�[���`�F���W�̃L�[���擾
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
        // �V�[���`�F���W�t���Ooff
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

        // �}�X�^�[�N���C�A���g���L�[�������ăV�[���ؑ�
        if (PhotonNetwork.IsMasterClient && ready)
        {
            if (Input.GetKey(SceneChangeKey) && !DontDestroy.instance.GetComponent<SceneChange>().load)
            {
                DontDestroy.instance.GetComponent<SceneChange>().load = true;
                DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
            }
        }

        // �ڑ�������\����؂�ւ���
        if (connect)
        {
            if(!settingtext)
            {
                StartAnounce.transform.Find("setting").gameObject.SetActive(true);
                settingtext = true;
            }
            //StartAnounce.transform.Find("conect").gameObject.SetActive(false);
            // �}�X�^�[�N���C�A���g�̓V�[���ؑփ{�^���̕\��
            if (PhotonNetwork.IsMasterClient && ready)
            {
                StartAnounce.transform.Find("press_button").gameObject.SetActive(true);
                StartAnounce.transform.Find("client").gameObject.SetActive(false);

            }
            // �N���C�A���g�̓}�X�^�[�N���C�A���g��҂\��
            else 
            {
                StartAnounce.transform.Find("press_button").gameObject.SetActive(false);
                StartAnounce.transform.Find("client").gameObject.SetActive(true);
            }
                
        }

        // �T�[�o�[�ɐڑ�
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