using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField]
    List<string> scenes = new List<string>();

    int index = 0;
    int max = 0;
    // Start is called before the first frame update
    void Start()
    {
        max = scenes.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(scenes[++index % max]);
    }
}
