using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveExplainBar : MonoBehaviour
{
    [SerializeField]
    KeyCode up = KeyCode.W;
    [SerializeField]
    KeyCode down = KeyCode.S;
    RectTransform rect;
    float startY;
    [SerializeField]
    float limit = 20.0f;
    [SerializeField]
    Vector2 speed = new Vector2(0,1.0f);
    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        startY = rect.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(up))
        {
            float pos = rect.localPosition.y;
            pos += speed.y;

            if (pos >= startY + limit)
                rect.localPosition = new Vector2(rect.localPosition.x, startY + limit);
            else
                rect.localPosition = new Vector2(rect.localPosition.x, pos);

        }
        if (Input.GetKey(down))
        {
            float pos = rect.localPosition.y;
            pos -= speed.y;

            if (pos <= startY - limit)
                rect.localPosition = new Vector2(rect.localPosition.x, startY - limit);
            else
                rect.localPosition = new Vector2(rect.localPosition.x, pos);
        }
    }
}
