using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    KeyCode SceneChangeKey = KeyCode.Space;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public KeyCode GetSceneChangeKey()
    {
        return SceneChangeKey;
    }
}
