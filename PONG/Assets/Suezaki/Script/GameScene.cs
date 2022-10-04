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
    // 試合情報
    Data.win battle_data = new Data.win();
    // Start is called before the first frame update
    void Start()
    {
        // スコアイベントの登録
        for(int i = 0; i < score.transform.childCount; ++i)
        DontDestroy.instance.GetComponent<Event>().ScoreEvent[i].AddListener(score.transform.GetChild(i).GetComponent<ShowScore>().ShowScoreText);
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.GetComponent<Ball>().ScorePlayerId > -1)
        {
            // 得点
            DontDestroy.instance.GetComponent<Data>().winner.name = score.transform.GetChild(ball.GetComponent<Ball>().ScorePlayerId).name;
            DontDestroy.instance.GetComponent<Event>().ScoreEvent[ball.GetComponent<Ball>().ScorePlayerId]?.Invoke(1, battle_data);
            ball.GetComponent<Ball>().ResetBall();


        }
        
        
        if(battle_data.flg)
        {
            // シーン遷移
            DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
        }
    }
}
