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
        // �R���[�`���J�n
        StartCoroutine("SetOffline");
    }

    IEnumerator SetOffline()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);

        // ���b��~
        yield return new WaitForSeconds(0.5f);

        DontDestroy.instance.GetComponent<SceneChange>().EndOfflineGame();
        DontDestroy.instance.GetComponent<Setting>().ResetSetting();
    }
}
