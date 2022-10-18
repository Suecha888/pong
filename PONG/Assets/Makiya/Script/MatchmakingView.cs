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

    public GameObject text;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        // ロビーに参加するまでは、入力できないようにする
        canvasGroup.interactable = false;

        // ルームリスト表示を初期化する
        roomListView.Init(this);

        roomNameInputField.onValueChanged.AddListener(OnRoomNameInputFieldValueChanged);
        createRoomButton.onClick.AddListener(OnCreateRoomButtonClick);
    }

    // マスターサーバーのロビーに入る時に呼ばれるコールバック
    public override void OnJoinedLobby()
    {
        // ロビーに参加したら、入力できるようにする
        canvasGroup.interactable = true;
        Debug.Log("ロビーに接続成功");
    }

    private void OnRoomNameInputFieldValueChanged(string value)
    {
        // ルーム名が1文字以上入力されている時のみ、ルーム作成ボタンを押せるようにする
        createRoomButton.interactable = (value.Length > 0);
    }

    private void OnCreateRoomButtonClick()
    {
        // ルーム作成処理中は、入力できないようにする
        canvasGroup.interactable = false;

        // 入力フィールドに入力したルーム名のルームを作成する
        var roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;             // ルームの上限人数を２人にする
        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
    }

    // サーバーがルームを作成出来なかった時に呼ばれるコールバック
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        // ルームの作成が失敗したら、再び入力できるようにする
        roomNameInputField.text = string.Empty;
        canvasGroup.interactable = true;
    }

    // ゲームサーバーに接続中
    public void OnJoiningRoom()
    {
        // ルーム参加処理中は、入力できないようにする
        canvasGroup.interactable = false;
    }

    // ゲームサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnJoinedRoom()
    {
        //if (PhotonNetwork.IsMasterClient)
        //{
        //    // テキストを表示
        //    text.SetActive(true);
        //}

        this.StartScene.GetComponent<StartScene>().Setconnect();

        // ルームへの参加が成功したら、UIを非表示にする
        //gameObject.SetActive(false);
        //Debug.Log("ゲームサーバーに接続成功");

    }

    // ゲームサーバーに接続が失敗した時に呼ばれるコールバック
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ルームへの参加が失敗したら、再び入力できるようにする
        canvasGroup.interactable = true;
    }
}