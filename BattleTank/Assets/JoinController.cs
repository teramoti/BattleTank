using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinController : MonoBehaviour
{

    bool IsjoinController;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 接続されているコントローラの名前を調べる
        //var controllerNames = Input.GetJoystickNames();

        string[] cName = Input.GetJoystickNames();

        for (int i = 0; i < cName.Length; i++)
        {
            if (cName[i] != "")
            {
                IsjoinController = true;
            }
            else
            {
                IsjoinController = false;
            }
        }

        // 一台もコントローラが接続されていなければエラー
        //if (controllerNames[0] == "") IsjoinController = false;
        print("げんざいcontrollerは" + IsjoinController + "です。");
    }


    public bool GetController()
    {
        return IsjoinController;
    }
}
