using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPressButton : MonoBehaviour
{
    // �V�[���I�u�W�F�N�g
    GameObject sceneObject;
    // �\���e�L�X�g
    TextMeshProUGUI pressButtonText;
    // Start is called before the first frame update
    void Start()
    {
        pressButtonText = GetComponent<TextMeshProUGUI>();
        sceneObject = GameObject.FindGameObjectWithTag("scene");
        // �\���e�L�X�g���e�ύX
        pressButtonText.text = new string( "press " + sceneObject?.GetComponent<Key>().GetSceneChangeKey().ToString());
    }
}
