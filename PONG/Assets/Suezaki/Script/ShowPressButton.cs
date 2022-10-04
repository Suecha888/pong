using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPressButton : MonoBehaviour
{
    [SerializeField]
    GameObject sceneObject;
    TextMeshProUGUI pressButtonText;
    // Start is called before the first frame update
    void Start()
    {
        pressButtonText = GetComponent<TextMeshProUGUI>();
        pressButtonText.text = new string( "press " + sceneObject?.GetComponent<Key>().GetSceneChangeKey().ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
