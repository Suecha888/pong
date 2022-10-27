using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoffline : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        // スコアイベントの登録
        for (int i = 0; i < score.transform.GetChild(0).transform.childCount; ++i)
            DontDestroy.instance.GetComponent<Event>().ScoreEvent[i].AddListener(score.transform.GetChild(0).transform.GetChild(i).GetComponent<ShowScore>().ShowScoreText);

    }

    // Update is called once per frame
    void Update()
    {
        if (battle_data.flg)
        {
            if (!scenechange)
            {
                message.SetActive(false);
                // シーン遷移
                DontDestroy.instance.GetComponent<SceneChange>().Invoke("OfflineSceneChange", EndToChangeTime);
                ball.GetComponent<balloffline1>().StopBall();
                scenechange = true;
            }
        }
        else
        {



            

            // press ~~ の表示
            if (ball.GetComponent<balloffline1>().GetBallMoveFlg())
            {
                if (ball.GetComponent<balloffline1>().GetBallDir() == 1)
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
                if (ball.GetComponent<balloffline1>().GetBallDir() == 1)
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
            if (ball.GetComponent<balloffline1>().ScorePlayerId > -1)
            {
                // 得点処理
                DontDestroy.instance.GetComponent<Data>().winner.name = score.transform.GetChild(0).transform.GetChild(ball.GetComponent<balloffline1>().ScorePlayerId).name;
                DontDestroy.instance.GetComponent<Event>().ScoreEvent[ball.GetComponent<balloffline1>().ScorePlayerId].Invoke(1, battle_data);
                // ボールの状態をリセット
                ball.GetComponent<balloffline1>().ResetBall();
            }

        }
    }
}
