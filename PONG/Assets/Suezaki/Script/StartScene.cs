using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartScene : MonoBehaviour
{
    private KeyCode SceneChangeKey;
    [SerializeField]
    private GameObject Luncher;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
        DontDestroy.instance.GetComponent<SceneChange>().load = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(SceneChangeKey) && DontDestroy.instance.GetComponent<SceneChange>().load)
        {
            DontDestroy.instance.GetComponent<SceneChange>().load = false;
            DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
        }

        if(Input.GetKey(KeyCode.C))
        {
            this.Luncher.GetComponent<Luncher>().Connect();

        }
    }
    
    
}
