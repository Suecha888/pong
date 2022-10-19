using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rename : MonoBehaviour
{
    public GameObject InputNamePanel;
    public GameObject MatchmakingView;
    public AudioClip SE1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void RenameClick()
    {
        // コルーチン開始
        StartCoroutine("SetPanel");
    }

    IEnumerator SetPanel()
    {
        // 音を鳴らす
        audioSource.PlayOneShot(SE1);

        // 数秒停止
        yield return new WaitForSeconds(0.5f);

        InputNamePanel.SetActive(true);
        MatchmakingView.SetActive(false);
    }
}
