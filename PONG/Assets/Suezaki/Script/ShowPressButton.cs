using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPressButton : MonoBehaviour
{
    // シーンオブジェクト
    GameObject sceneObject;
    // 表示テキスト
    TextMeshProUGUI pressButtonText;
    // Start is called before the first frame update
    void Start()
    {
        pressButtonText = GetComponent<TextMeshProUGUI>();
        sceneObject = GameObject.FindGameObjectWithTag("scene");
        // 表示テキスト内容変更
        pressButtonText.text = new string( "press " + sceneObject?.GetComponent<Key>().GetSceneChangeKey().ToString());
    }
}
