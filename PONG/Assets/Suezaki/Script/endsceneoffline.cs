using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endsceneoffline : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;

    // �V�[����؂�ւ���L�[
    private KeyCode SceneChangeKey;
    // ���ҕ\���I�u�W�F�N�g
    [SerializeField] GameObject winner;
    // ���Җ�
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
            // ����炷
            audioSource.PlayOneShot(SE1);
            DontDestroy.instance.GetComponent<SceneChange>().OfflineSceneChange();
        }
    }
}
