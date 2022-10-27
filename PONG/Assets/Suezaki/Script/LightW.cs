using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightW : MonoBehaviour
{
    [SerializeField]
    KeyCode key = KeyCode.W;
    [SerializeField]
    Gradient gradient;
    TextMeshProUGUI text;
    float time = 0.0f;
    // ”{—¦
    [SerializeField]
    float times = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(key))
        {
            text.color = gradient.Evaluate(Mathf.PingPong(time, 1.0f));
            time += Time.deltaTime * times;
        }
        else
        {
            text.color = Color.white;
            time = 0.0f;
        }
    }
}
