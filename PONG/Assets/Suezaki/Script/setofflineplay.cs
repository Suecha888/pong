using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setofflineplay : MonoBehaviour
{
    public AudioClip SE1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    public void playofflineClicksdOffline()
    {
        // ‰¹‚ð–Â‚ç‚·
        audioSource.PlayOneShot(SE1);
        DontDestroy.instance.GetComponent<SceneChange>().PlayOfflineGame();
    }
}
