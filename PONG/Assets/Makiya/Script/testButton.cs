using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class testButton : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Button createRoomButton = default;

    public GameObject TitlePanel;
    public GameObject InputNamePanel;
    public AudioClip SE1;
    AudioSource audioSource;
    private RoomList roomList = new RoomList();     // �쐬�������[���̃��X�g

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        createRoomButton.onClick.AddListener(ClickStart);
    }

    public void ClickStart()
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

        // Photon�T�[�o�[�ɐڑ����Ă��Ȃ�������
        if (!PhotonNetwork.IsConnected)
        {
            InputNamePanel.SetActive(true);
            TitlePanel.SetActive(false);
        }
        else
        {
            roomList.Clear();
            // �ݒ�̏�����
            DontDestroy.instance.GetComponent<Setting>().ResetSetting();
            InputNamePanel.SetActive(true);
            TitlePanel.SetActive(false);
        }
    }
}
