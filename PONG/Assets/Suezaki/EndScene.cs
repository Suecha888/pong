using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    [SerializeField]
    KeyCode key = KeyCode.Space;

    [SerializeField]
    GameObject manager = new GameObject();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            manager.GetComponent<SceneChange>().ChangeScene();
        }
    }
}
