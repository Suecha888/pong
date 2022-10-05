using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameScene : MonoBehaviour
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
        BallStartKey = GetComponent<Key>().GetBallStartKey();
        // スコアイベントの登録
        for (int i = 0; i < score.transform.childCount; ++i)
        DontDestroy.instance.GetComponent<Event>().ScoreEvent[i].AddListener(score.transform.GetChild(i).GetComponent<ShowScore>().ShowScoreText);
    }

    // Update is called once per frame
    void Update()
    {
        if (battle_data.flg && !scenechange)
        {
            // シーン遷移
            DontDestroy.instance.GetComponent<SceneChange>().Invoke("ChangeScene", EndToChangeTime);
            ball.GetComponent<Ball>().StopBall();
            scenechange = true;
        }

        if (ball.GetComponent<Ball>().ScorePlayerId > -1)
        {
            message.SetActive(true);
            // 得点
            DontDestroy.instance.GetComponent<Data>().winner.name = score.transform.GetChild(ball.GetComponent<Ball>().ScorePlayerId).name;
            DontDestroy.instance.GetComponent<Event>().ScoreEvent[ball.GetComponent<Ball>().ScorePlayerId]?.Invoke(1, battle_data);
            ball.GetComponent<Ball>().ResetBall();
        }
        
        if(!ball.GetComponent<Ball>().GetBallMoveFlg())
        {
            message.SetActive(false);
        }
        
        
    }
}
