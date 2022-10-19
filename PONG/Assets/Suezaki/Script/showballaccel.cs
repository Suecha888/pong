using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class showballaccel : MonoBehaviourPun
{
    // 加速するかどうか
    bool accel = false;
    // 表示テキスト
    TextMeshProUGUI accelText;
    // Start is called before the first frame update
    void Start()
    {
        accelText = GetComponent<TextMeshProUGUI>();
        ShowAccel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            photonView.RPC(nameof(SetAccelSwitch), RpcTarget.All);
        }
    }
    public void ShowAccel()
    {
        accel = DontDestroy.instance.GetComponent<Setting>().GetBallAccel();
        if(accel)
            accelText.text = "Ball Accel   :  " + $"<color=#{matchsetting.TextColor.RED:X}>" + accel.ToString() + "</color>";
        else
            accelText.text = "Ball Accel   :  " + $"<color=#{matchsetting.TextColor.BLUE:X}>" + accel.ToString() + "</color>";

    }
    [PunRPC]
    public void SetAccelSwitch()
    {
        DontDestroy.instance.GetComponent<Setting>().SwitchBallAccel();
        ShowAccel();
    }
}
