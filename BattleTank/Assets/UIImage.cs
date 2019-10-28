using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIImage : MonoBehaviour
{
    //キーボードの場合
    public GameObject keyboardImage;

    //コントローラーの場合
    public GameObject controllerImage;

    GameObject join;

    JoinController script;

    bool IsJoinController;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        join = GameObject.Find("GameManager");
        script = join.GetComponent<JoinController>();

        IsJoinController = script.GetController();

        if (IsJoinController==true)
        {
            //コントローラーがあったら
            controllerImage.SetActive(true);
            keyboardImage.SetActive(false);

        }
        else
        {
            //コントローラーがないなら
            keyboardImage.SetActive(true);
            controllerImage.SetActive(false);

        }
    }
}
