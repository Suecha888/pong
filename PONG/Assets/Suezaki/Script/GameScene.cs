using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameScene : MonoBehaviour
{

    float timer = 0;
    [SerializeField] GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(score.transform.GetChild(0).ToString());
        //DontDestroy.instance.GetComponent<Event>().ScoreEvent = new UnityEvent<int>[score.transform.childCount];
        for(int i = 0; i < score.transform.childCount; ++i)
        DontDestroy.instance.GetComponent<Event>().ScoreEvent[i].AddListener(score.transform.GetChild(i).GetComponent<ShowScore>().ShowScoreText);
        //DontDestroy.instance.GetComponent<Event>().ScoreEvent[1].AddListener(score.transform.GetChild(1).GetComponent<ShowScore>().ShowScoreText);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            DontDestroy.instance.GetComponent<Event>().ScoreEvent[0]?.Invoke(1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            DontDestroy.instance.GetComponent<Event>().ScoreEvent[1]?.Invoke(1);
        }
        timer += Time.deltaTime;
        
        if(timer >= 5)
        {
            DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
        }
    }
}
