using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class END : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �Q�[�����I������
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}