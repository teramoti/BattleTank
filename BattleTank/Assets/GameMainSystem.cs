using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainSystem : MonoBehaviour
{
    [SerializeField]
    tutorialText textController=null;
    bool IsTextPush = false;
    //[SerializeField]
    //ClickController clickController;
    void Update()
    {
        if (textController.finished)
        {
            textController.finished = false;
            //clickController.ViewClickIcon();
            return;
        }
        textController.TextUpdate(IsTextPush);
        IsTextPush = false;

        if(Input.GetButtonDown("Fire2"))
        {
            PushText();
        }
    }
    public void PushText()
    {
        IsTextPush = true;
    }
}