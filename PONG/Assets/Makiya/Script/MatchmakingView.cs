using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MatchmakingView : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private RoomView roomListView = default;
    [SerializeField]
    private TMP_InputField roomNameInputField = default;
    [SerializeField]
    private Button createRoomButton = default;
    [SerializeField]
    private GameObject StartScene;

    private CanvasGroup canvasGroup;
    public AudioClip SE1;
    AudioSource audioSource;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        // ���r�[�ɎQ������܂ł́A���͂ł��Ȃ��悤�ɂ���
        canvasGroup.interactable = false;

        // ���[�����X�g�\��������������
        roomListView.Init(this);

        roomNameInputField.onValueChanged.AddListener(OnRoomNameInputFieldValueChanged);
        createRoomButton.onClick.AddListener(OnCreateRoomButtonClick);

        audioSource = GetComponent<AudioSource>();
    }

    // �}�X�^�[�T�[�o�[�̃��r�[�ɓ��鎞�ɌĂ΂��R�[���o�b�N
    public override void OnJoinedLobby()
    {
        // ���r�[�ɎQ��������A���͂ł���悤�ɂ���
        canvasGroup.interactable = true;
        Debug.Log("���r�[�ɐڑ�����");
    }

    private void OnRoomNameInputFieldValueChanged(string value)
    {
        // ���[������1�����ȏ���͂���Ă��鎞�̂݁A���[���쐬�{�^����������悤�ɂ���
        createRoomButton.interactable = (value.Length > 0);
    }

    private void OnCreateRoomButtonClick()
    {
        // ���[���쐬�������́A���͂ł��Ȃ��悤�ɂ���
        canvasGroup.interactable = false;
        // ����炷
        audioSource.PlayOneShot(SE1);
        // ���̓t�B�[���h�ɓ��͂������[�����̃��[�����쐬����
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;             // ���[���̏���l�����Q�l�ɂ���
        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
    }

    // �T�[�o�[�����[�����쐬�o���Ȃ��������ɌĂ΂��R�[���o�b�N
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        // ���[���̍쐬�����s������A�Ăѓ��͂ł���悤�ɂ���
        roomNameInputField.text = string.Empty;
        canvasGroup.interactable = true;
    }

    // �Q�[���T�[�o�[�ɐڑ���
    public void OnJoiningRoom()
    {
        // ���[���Q���������́A���͂ł��Ȃ��悤�ɂ���
        canvasGroup.interactable = false;
    }

    // �Q�[���T�[�o�[�ւ̐ڑ��������������ɌĂ΂��R�[���o�b�N
    public override void OnJoinedRoom()
    {
        this.StartScene.GetComponent<StartScene>().Setconnect();

        // ���[���ւ̎Q��������������AUI���\���ɂ���
        gameObject.SetActive(false);
    }

    // �Q�[���T�[�o�[�ɐڑ������s�������ɌĂ΂��R�[���o�b�N
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ���[���ւ̎Q�������s������A�Ăѓ��͂ł���悤�ɂ���
        canvasGroup.interactable = true;
    }
}