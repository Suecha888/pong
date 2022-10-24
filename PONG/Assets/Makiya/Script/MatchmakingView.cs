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
    private GameObject startScene;

    private CanvasGroup canvasGroup;
    public AudioClip SE1;
    AudioSource audioSource;
    public TMP_Text namenum;
    int Maxname = 6;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        // ロビーに参加するまでは、入力できないようにする
        canvasGroup.interactable = false;
        // ルーム作成ボタンを押せなくする
        createRoomButton.interactable = false;
        // ルームリスト表示を初期化する
        roomListView.Init(this);

        roomNameInputField.onValueChanged.AddListener(OnRoomNameInputFieldValueChanged);
        createRoomButton.onClick.AddListener(OnCreateRoomButtonClick);

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 名前の文字数表示
        namenum.SetText("{0}/{1}", roomNameInputField.text.Length, Maxname);
    }

    // マスターサーバーへの接続が成功した時に呼ばれるコールバック
    public override void OnConnectedToMaster()
    {
        Debug.Log("ルームを退出");
        // ロビーに参加
        PhotonNetwork.JoinLobby();
    }

    // マスターサーバーのロビーに入る時に呼ばれるコールバック
    public override void OnJoinedLobby()
    {
        // ロビーに参加したら、入力できるようにする
        canvasGroup.interactable = true;
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
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);
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
        this.startScene.GetComponent<StartScene>().Setconnect();

        // ルームへの参加が成功したら、UIを非表示にする
        gameObject.SetActive(false);
        if (PhotonNetwork.IsMasterClient && SceneChange.backroom)
        {
            SceneChange.backroom = false;
        }
        if(!PhotonNetwork.IsMasterClient && SceneChange.backroom2)
        {
            SceneChange.backroom2 = false;
        }
    }

    // ゲームサーバーに接続が失敗した時に呼ばれるコールバック
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        // ルームへの参加が失敗したら、再び入力できるようにする
        canvasGroup.interactable = true;
    }
}