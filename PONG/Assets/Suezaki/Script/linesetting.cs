using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateLine))]
public class linesetting : Editor
{
    public override void OnInspectorGUI()
    {
        // 元のインスペクター部分を表示
        base.OnInspectorGUI();

        // targetを変換して対象を取得
        CreateLine createLine = target as CreateLine;
        
        if (GUILayout.Button("SetLine"))
        {
            createLine.ResetLine();
        }

      
    }
}
