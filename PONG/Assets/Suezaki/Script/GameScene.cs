using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Photon.Pun;
public class GameScene : MonoBehaviourPunCallbacks,IPunObservable
{
    // プレイヤーのスコアオブジェクト
    [SerializeField] GameObject score;
    // ボール
    [SerializeField] GameObject ball;
    // ボタン案内
    [SerializeField] GameObject message;

    // 試合情報
    Data.win battle_data = new Data.win();
    // 試合終了から遷移までの時間
    [SerializeField] float EndToChangeTime = 1.0f;
    
    private KeyCode BallStartKey;

    private bool scenechange = false;
    // Start is called before the first frame update
    void Start()
    {
        

        ball = GameObject.FindGameObjectWithTag("Ball");
        score = GameObject.Find("score(Clone)");
        message = GameObject.Find("pressbutton(Clone)");
        // クライアント（マスター以外）の場合にずれてしまうシーンのインデックスを整理
        if (DontDestroy.instance.GetComponent<SceneChange>().getIndex() != 1)
        DontDestroy.instance.GetComponent<SceneChange>().setIndex(1);

        DontDestroy.instance.GetComponent<SceneChange>().leave = false;
           BallStartKey = GetComponent<Key>().GetBallStartKey();
        // スコアイベントの登録
        for (int i = 0; i < score.transform.GetChild(0).transform.childCount; ++i)
        DontDestroy.instance.GetComponent<Event>().ScoreEvent[i].AddListener(score.transform.GetChild(0).transform.GetChild(i).GetComponent<ShowScore>().ShowScoreText);

        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.C))
        {
            //if(PhotonNetwork.IsMasterClient)
            DontDestroy.instance.GetComponent<SceneChange>().UpdateLeave();
            DontDestroy.instance.GetComponent<SceneChange>().LeaveRoom();
        }
        if(battle_data.flg)
        {
            if (!scenechange)
            {
                message.SetActive(false);
                // シーン遷移
                DontDestroy.instance.GetComponent<SceneChange>().Invoke("ChangeScene", EndToChangeTime);
                ball.GetComponent<Ball>().StopBall();
                scenechange = true;
            }
        }
        else
        {
            // press ~~ の表示
            if (ball.GetComponent<Ball>().GetBallMoveFlg())
            {
                message.SetActive(true);
            }
            else
            {
                message.SetActive(false);
            }


            if (ball.GetComponent<Ball>().ScorePlayerId > -1)
            {// 得点
                DontDestroy.instance.GetComponent<Data>().winner.name = score.transform.GetChild(0).transform.GetChild(ball.GetComponent<Ball>().ScorePlayerId).name;
                DontDestroy.instance.GetComponent<Event>().ScoreEvent[ball.GetComponent<Ball>().ScorePlayerId].Invoke(1, battle_data);
                ball.GetComponent<Ball>().ResetBall();
            }

            
        }

        
        
        
    }
    void IPunObservable.OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(score);
            stream.SendNext(ball);
            stream.SendNext(message);
            stream.SendNext(battle_data);
        }
        else
        {
            score = (GameObject)stream.ReceiveNext();
            ball = (GameObject)stream.ReceiveNext();
            message = (GameObject)stream.ReceiveNext();
            battle_data = (Data.win)stream.ReceiveNext();
        }
    }

    
}
