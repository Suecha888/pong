using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackRoomOffline : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }
    public void BackButtonClicksdOffline()
    {
        // コルーチン開始
        StartCoroutine("SetOffline");
    }

    IEnumerator SetOffline()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);

        // 数秒停止
        yield return new WaitForSeconds(0.5f);

        DontDestroy.instance.GetComponent<SceneChange>().EndOfflineGame();
        DontDestroy.instance.GetComponent<Setting>().ResetSetting();
    }
}
