using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class showreflectball : MonoBehaviourPun
{
    // ���˂��邩�ǂ���
    bool bound = false;
    // �\���e�L�X�g
    TextMeshProUGUI boundText;
    // Start is called before the first frame update
    void Start()
    {
        boundText = GetComponent<TextMeshProUGUI>();
        ShowReflect();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            photonView.RPC(nameof(SetReflectSwitch), RpcTarget.All);
        }
    }
    public void ShowReflect()
    {
        bound = DontDestroy.instance.GetComponent<Setting>().GetBallBound();
        if(bound)
            boundText.text = "Random Bound :  " + $"<color=#{matchsetting.TextColor.RED:X}>"+bound.ToString()+"</color>";
        else
            boundText.text = "Random Bound :  " + $"<color=#{matchsetting.TextColor.BLUE:X}>" + bound.ToString() + "</color>";
    }
    [PunRPC]
    public void SetReflectSwitch()
    {
        DontDestroy.instance.GetComponent<Setting>().SwitchBallBound();
        ShowReflect();
    }
    
}