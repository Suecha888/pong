using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endsceneoffline : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;

    // シーンを切り替えるキー
    private KeyCode SceneChangeKey;
    // 勝者表示オブジェクト
    [SerializeField] GameObject winner;
    // 勝者名
    [SerializeField]
    string winnername = "";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroy.instance.GetComponent<Setting>().ResetSetting();
        audioSource = GetComponent<AudioSource>();
        DontDestroy.instance.GetComponent<Event>().WinnerEvent.AddListener(winner.GetComponent<ShowWinner>().showWinnerOffline);
        DontDestroy.instance.GetComponent<Event>().WinnerEvent.Invoke(DontDestroy.instance.GetComponent<Data>().winner.name);
        winnername = DontDestroy.instance.GetComponent<Data>().winner.name;
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(SceneChangeKey))
        {
            // 音を鳴らす
            audioSource.PlayOneShot(SE1);
            DontDestroy.instance.GetComponent<SceneChange>().OfflineSceneChange();
        }
    }
}
