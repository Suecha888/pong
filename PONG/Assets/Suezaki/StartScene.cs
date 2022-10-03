using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartScene : MonoBehaviour
{
    [SerializeField]
    KeyCode key = KeyCode.Space;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(key))
        {
            DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
        }
    }
}
