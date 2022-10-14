using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomViewElement : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nameLabel = default;        // ���[����
    [SerializeField]
    private TextMeshProUGUI playerCounter = default;    // ���݂̃v���C���[�l��

    private MatchmakingView matchmakingView;
    private Button button;

    public void Init(MatchmakingView parentView)
    {
        matchmakingView = parentView;

        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        // ���[���ɎQ���������́A���͂ł��Ȃ��悤�ɂ���
        matchmakingView.OnJoiningRoom();

        // �{�^���ɑΉ��������[�����̃��[���ɎQ������
        PhotonNetwork.JoinRoom(nameLabel.text);
    }

    public void Show(RoomInfo roomInfo)
    {
        // ���[������\��
        nameLabel.text = roomInfo.Name;
        // ���݂̃��[���̐l����\��
        playerCounter.SetText("{0}/{1}", roomInfo.PlayerCount, roomInfo.MaxPlayers);

        // ���[���������łȂ����̂݁A�Q���{�^����������悤�ɂ���
        button.interactable = (roomInfo.PlayerCount < roomInfo.MaxPlayers);

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
