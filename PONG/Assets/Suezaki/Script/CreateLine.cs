using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CreateLine : MonoBehaviour
{
    // ラインを構成する１ピースのオブジェクト
    [SerializeField] GameObject line_peace;
    // セットの数
    [SerializeField,Min(1)] int set_num;
    // ピースとピースの間隔
    [SerializeField,Min(0)] float space;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < set_num; i++)
        {
            // ピース（上）
            GameObject peace_up = Instantiate(line_peace);
            peace_up.transform.position = new Vector3(0, space * i, 0);
            peace_up.transform.parent = transform;
            // ピース（下）
            GameObject peace_down = Instantiate(line_peace);
            peace_down.transform.position = new Vector3(0, -space * i, 0);
            peace_down.transform.parent = transform;
        }
    }

    public void ResetLine()
    {
        // 子オブジェクトの削除
        foreach (Transform child in gameObject.transform)
        {
            DestroyImmediate(child.gameObject);
        }
        // 更新
        for (int i = 0; i < set_num; i++)
        {
            // ピース（上）
            GameObject peace_up = Instantiate(line_peace);
            peace_up.transform.position = new Vector3(0, space * i, 0);
            peace_up.transform.parent = transform;
            // ピース（下）
            GameObject peace_down = Instantiate(line_peace);
            peace_down.transform.position = new Vector3(0, -space * i, 0);
            peace_down.transform.parent = transform;
        }
    }

   
}
