using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CreateLine))]
public class linesetting : Editor
{
    public override void OnInspectorGUI()
    {
        // ���̃C���X�y�N�^�[������\��
        base.OnInspectorGUI();

        // target��ϊ����đΏۂ��擾
        CreateLine createLine = target as CreateLine;
        
        if (GUILayout.Button("SetLine"))
        {
            createLine.ResetLine();
        }

      
    }
}
