using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    // �V�[���ؑւ̃L�[
    [SerializeField]
    KeyCode SceneChangeKey = KeyCode.Space;
    // �{�[���X�^�[�g�̃L�[
    [SerializeField]
    KeyCode BallStartKey = KeyCode.Space;


    // �V�[���ؑւ̃L�[�擾
    public KeyCode GetSceneChangeKey()
    {
        return SceneChangeKey;
    }
    // �{�[���X�^�[�g�̃L�[�擾
    public KeyCode GetBallStartKey()
    {
        return BallStartKey;
    }
}
