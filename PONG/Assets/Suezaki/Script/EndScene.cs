using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    private KeyCode SceneChangeKey;

    // Start is called before the first frame update
    void Start()
    {
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(SceneChangeKey))
        {
            DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
        }
    }
}
