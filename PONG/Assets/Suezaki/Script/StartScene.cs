#if true
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class StartScene : MonoBehaviour
{
    private KeyCode SceneChangeKey;
    [SerializeField]
    private GameObject Luncher;

    [SerializeField]
    private GameObject StartAnounce;
    bool connect = false;
    // Start is called before the first frame update
    void Start()
    {
        StartAnounce.transform.Find("conect").gameObject.SetActive(true);
        

        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
        DontDestroy.instance.GetComponent<SceneChange>().load = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (Input.GetKey(SceneChangeKey) && DontDestroy.instance.GetComponent<SceneChange>().load)
            {
                DontDestroy.instance.GetComponent<SceneChange>().load = false;
                DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
            }
        }

        if (connect)
        {
            StartAnounce.transform.Find("conect").gameObject.SetActive(false);
            if (PhotonNetwork.IsMasterClient)
            {
                StartAnounce.transform.Find("press_button").gameObject.SetActive(true);
                StartAnounce.transform.Find("client").gameObject.SetActive(false);

            }
            else
            {
                StartAnounce.transform.Find("press_button").gameObject.SetActive(false);
                StartAnounce.transform.Find("client").gameObject.SetActive(true);
            }
                
        }

        if (Input.GetKey(KeyCode.C))
        {
            this.Luncher.GetComponent<Luncher>().Connect();
            connect = true;
        }

        
    }
    

    
}
#else
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartScene : MonoBehaviour
{
    private KeyCode SceneChangeKey;
    [SerializeField]
    private GameObject Luncher;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
        DontDestroy.instance.GetComponent<SceneChange>().load = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(SceneChangeKey) && DontDestroy.instance.GetComponent<SceneChange>().load)
        {
            DontDestroy.instance.GetComponent<SceneChange>().load = false;
            DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
        }

        if(Input.GetKey(KeyCode.C))
        {
            this.Luncher.GetComponent<Luncher>().Connect();

        }
    }
    
    
}
#endif