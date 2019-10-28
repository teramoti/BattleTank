using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    public GameObject keyBoardUI;
    public GameObject controllerUI; 
    private bool pauseGame = false;

    bool IsPause;

    GameObject join;

    JoinController script;

    bool IsJoinController;

    void Start()
    {
        OnUnPause();
        IsPause = false;

    }

    public void Update()
    {
        join = GameObject.Find("GameManager");
        script = join.GetComponent<JoinController>();
        bool flag = Input.GetButtonDown("Pause");
        if (flag==true)
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                OnPause();
            }
            else
            {
                OnUnPause();
            }
        }

        if(IsPause==true)
        {
            ChangeController();
        }

    }

    public void OnPause()
    {
        IsPause = true;
        //ゲーム中断

        Time.timeScale = 0;

        pauseGame = true;
    }

    public void OnUnPause()
    {
        IsPause = false;
        //中断をやめる
        keyBoardUI.SetActive(false);       // PanelMenuをfalseにする

        controllerUI.SetActive(false);      // PanelEscをtrueにする

        Time.timeScale = 1;

        pauseGame = false;

    }

    void ChangeController()
    {

        IsJoinController = script.GetController();

        if (IsJoinController == true)
        {
            //コントローラーがあったら
            controllerUI.SetActive(true);
            keyBoardUI.SetActive(false);

        }
        else
        {
            //コントローラーがないなら
            keyBoardUI.SetActive(true);
            controllerUI.SetActive(false);

        }
    }
}