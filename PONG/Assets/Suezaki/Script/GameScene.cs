using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameScene : MonoBehaviour
{
    // プレイヤーのスコアオブジェクト
    [SerializeField] GameObject score;
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
        if (Input.GetKey(KeyCode.Space))
        {
            // 得点
            DontDestroy.instance.GetComponent<Data>().winner.name = score.transform.GetChild(0).name;
            DontDestroy.instance.GetComponent<Event>().ScoreEvent[0]?.Invoke(1, battle_data);
        }
        if (Input.GetKey(KeyCode.A))
        {
            // 得点
            DontDestroy.instance.GetComponent<Data>().winner.name = score.transform.GetChild(1).name;
            DontDestroy.instance.GetComponent<Event>().ScoreEvent[1]?.Invoke(1, battle_data);
        }
        
        if(battle_data.flg)
        {
            // シーン遷移
            DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
        }
    }
}
