using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �J�������Z�b�g
        this.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
}
