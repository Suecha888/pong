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
        // �R���[�`���J�n
        StartCoroutine("SetPanel");
    }

    IEnumerator SetPanel()
    {
        // ����炷
        audioSource.PlayOneShot(SE1);

        // ���b��~
        yield return new WaitForSeconds(0.5f);

        InputNamePanel.SetActive(true);
        MatchmakingView.SetActive(false);
    }
}
