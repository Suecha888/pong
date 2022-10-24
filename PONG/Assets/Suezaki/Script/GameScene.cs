using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;

public class GameScene : MonoBehaviourPunCallbacks
{
    // プレイヤーのスコアオブジェクト
    [SerializeField] GameObject score;
    // ボール
    [SerializeField] GameObject ball;
    // ボタン案内
    [SerializeField] GameObject message;

    // 試合情報
    [SerializeField]
    Data.win battle_data = new Data.win();

    // 試合終了から遷移までの時間
    [SerializeField] float EndToChangeTime = 1.0f;
    

    private bool scenechange = false;

    private bool setobjFlg = false;
    // Start is called before the first frame update
    void Start()
    {
        SceneChange.gameScene = true;

        // ルームオブジェクトの取得
        ball = GameObject.FindGameObjectWithTag("Ball");
        //if (ball == null)
        //    setobjFlg = false;
        score = GameObject.Find("score(Clone)");
        message = GameObject.Find("pressbutton(Clone)");
        //setobj();


        // クライアント（マスター以外）の場合にずれてしまうシーンのインデックスを整理
        if (DontDestroy.instance.GetComponent<SceneChange>().getIndex() != 1)
        DontDestroy.instance.GetComponent<SceneChange>().setIndex(1);

        DontDestroy.instance.GetComponent<SceneChange>().leave = false;

        // スコアイベントの登録
        for (int i = 0; i < score.transform.GetChild(0).transform.childCount; ++i)
        DontDestroy.instance.GetComponent<Event>().ScoreEvent[i].AddListener(score.transform.GetChild(0).transform.GetChild(i).GetComponent<ShowScore>().ShowScoreText);
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(!setobjFlg)
        //{
        //    setobjFlg = true;
        //    setobj();
        //}

        // 決着がついたかどうか
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
                if(ball.GetComponent<Ball>().GetBallDir() == 1)
                {
                    message.transform.Find("right").gameObject.SetActive(true);
                }
                else
                {
                    message.transform.Find("left").gameObject.SetActive(true);
                }
                message.SetActive(true);
            }
            else
            {
                if (ball.GetComponent<Ball>().GetBallDir() == 1)
                {
                    message.transform.Find("right").gameObject.SetActive(false);
                }
                else
                {
                    message.transform.Find("left").gameObject.SetActive(false);
                }
                message.SetActive(false);
            }

            // どちらかが得点
            if (ball.GetComponent<Ball>().ScorePlayerId > -1)
            {
                // 得点処理
                DontDestroy.instance.GetComponent<Data>().winner.name = score.transform.GetChild(0).transform.GetChild(ball.GetComponent<Ball>().ScorePlayerId).name;
                DontDestroy.instance.GetComponent<Event>().ScoreEvent[ball.GetComponent<Ball>().ScorePlayerId].Invoke(1, battle_data);
                // ボールの状態をリセット
                ball.GetComponent<Ball>().ResetBall();
            }

            
        }

        
        
        
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player other)
    {
        DontDestroy.instance.GetComponent<SceneChange>().UpdateLeave();
        DontDestroy.instance.GetComponent<SceneChange>().LeaveRoom();
    }

    //void setobj()
    //{
    //    ball = GameObject.FindGameObjectWithTag("Ball");
    //    if (ball == null)
    //        setobjFlg = false;
    //    score = GameObject.Find("score(Clone)");
    //    message = GameObject.Find("pressbutton(Clone)");
    //}

}
