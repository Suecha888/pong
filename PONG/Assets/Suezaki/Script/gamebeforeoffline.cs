using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamebeforeoffline : MonoBehaviour
{
    // �V�[���ؑւ̃L�[
    private KeyCode SceneChangeKey;
    public AudioClip SE1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        // �V�[���`�F���W�̃L�[���擾
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(SceneChangeKey))
        {
            DontDestroy.instance.GetComponent<SceneChange>().OfflineSceneChange();
        }
    }
}
