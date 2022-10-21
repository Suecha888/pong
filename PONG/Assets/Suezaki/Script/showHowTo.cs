using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showHowTo : MonoBehaviour
{
#if false
    RectTransform rect;
    Vector2 startpos = new Vector2();
    [SerializeField]
    Vector2 distance = new Vector2(0, 200.0f); 
    bool onFlg = false;
    bool Move = false;
    [SerializeField]
    Vector2 speed = new Vector2(0,1.0f);
    [SerializeField]
    float a;
    [SerializeField]
    AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        startpos = rect.localPosition;
        rect.localPosition = startpos + distance;
    }

    // Update is called once per frame
    void Update()
    {
        if(onFlg)
        {
            speed.y += Time.deltaTime * a;
            if(Move)
            {
                
                float posX = rect.localPosition.x - speed.x;
                float posY = rect.localPosition.y - speed.y;

                if(posY < startpos.y)
                {
                    rect.localPosition = startpos;
                    onFlg = false;
                }
                else
                {
                    rect.localPosition = new Vector2(posX,posY);
                }

            }
            else
            {
                float posX = rect.localPosition.x + speed.x;
                float posY = rect.localPosition.y + speed.y;

                if (posY > startpos.y + distance.y)
                {
                    rect.localPosition = startpos + distance;
                    onFlg = false;
                }
                else
                {
                    rect.localPosition = new Vector2(posX, posY);
                }

            }

            rect.localPosition = new Vector2(rect.localPosition.x, curve.Evaluate(speed.y));
            if (speed.y >= curve[curve.length - 1].time )
            {
                speed.y = curve[curve.length - 1].time;
                onFlg = false;
            }
            else if( speed.y <= curve[0].time)
            {
                speed.y = curve[0].time;
                onFlg = false;
            }
        }
    }

    public void showhowto()
    {
        onFlg = true;
        Move = !Move;
        speed.y = 0;
    }
#else
    RectTransform rect;
    bool onFlg = false;
    bool Move = false;
    [SerializeField]
    float time = 0;
    [SerializeField]
    float a = 1;
    [SerializeField]
    AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.localPosition = new Vector2(rect.localPosition.x, curve.Evaluate(time));
    }

    // Update is called once per frame
    void Update()
    {
        if(onFlg)
        {
            if(Move)
            {
                time += Time.deltaTime * a;
            }
            else
            {
                time -= Time.deltaTime * a;

            }

            rect.localPosition = new Vector2(rect.localPosition.x, curve.Evaluate(time));

            if (time >= curve[curve.length - 1].time )
            {
                time = curve[curve.length - 1].time;
                onFlg = false;
            }
            else if(time <= curve[0].time)
            {
                time = curve[0].time;
                onFlg = false;
            }
        }
    }

    public void showhowto()
    {
        onFlg = true;
        Move = !Move;
    }
#endif
}