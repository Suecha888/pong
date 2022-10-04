using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    private KeyCode SceneChangeKey;
    [SerializeField] GameObject winner;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroy.instance.GetComponent<Event>().WinnerEvent?.AddListener(winner.GetComponent<ShowWinner>().showWinner);
        // èüé“ÇÃï\é¶
        DontDestroy.instance.GetComponent<Event>().WinnerEvent?.Invoke(DontDestroy.instance.GetComponent<Data>().winner.name);
        SceneChangeKey = GetComponent<Key>().GetSceneChangeKey();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(SceneChangeKey))
        {
            DontDestroy.instance.GetComponent<SceneChange>().ChangeScene();
        }
    }
}
