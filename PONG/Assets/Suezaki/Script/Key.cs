using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // シーン切替のキー
    [SerializeField]
    KeyCode SceneChangeKey = KeyCode.Space;
    // ボールスタートのキー
    [SerializeField]
    KeyCode BallStartKey = KeyCode.Space;


    // シーン切替のキー取得
    public KeyCode GetSceneChangeKey()
    {
        return SceneChangeKey;
    }
    // ボールスタートのキー取得
    public KeyCode GetBallStartKey()
    {
        return BallStartKey;
    }
}
