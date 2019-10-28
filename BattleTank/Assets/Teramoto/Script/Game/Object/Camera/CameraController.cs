using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
    public Camera mainCamera;
    public Camera subCamera;
    public Camera gameOverCaremra;
    public GameObject obj;
    private bool mainCameraON = true;

    bool deathFlag;

    public GameObject loseImage;
    float activetime;

    float movementInputValue;

    GameObject tank;
    TankHealth script;

    GameObject gamectr;
    GameClearController ctr;

    void Start()
    {
        tank = GameObject.Find("Tank");
        script = tank.GetComponent<TankHealth>();


        gamectr = GameObject.Find("GameManager");
        ctr = gamectr.GetComponent<GameClearController>();

        mainCamera.enabled = true;
        subCamera.enabled = false;
        gameOverCaremra.enabled = false;
        // ★追加
        // 客観カメラの場合、照準器をオフにする。
       // aimImage.SetActive(false);
        loseImage.SetActive(false);
        activetime = 0.0f;
        deathFlag = false;

    }

    void Update()
    {

        bool input = Input.GetButtonDown("Fire3");
        if (script.tankHP < 0)
        {
            deathFlag = true;
            activetime++;
            // カメラを切り替える。 
            gameOverCaremra.enabled = true;
            mainCamera.enabled = false;
            subCamera.enabled = false;
            mainCameraON = false;

        if(activetime%9==0)
            {
                loseImage.SetActive(false);
            }
        else
            {
                loseImage.SetActive(true);

            }

        }


        if(ctr.GetAnimeFlag()==true)
        {
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainCameraON = false;
           // aimImage.SetActive(false);


        }
        else
        {
            if (deathFlag == false)
            {

                if (input == true && mainCameraON == true)
                {
                    mainCamera.enabled = false;
                    subCamera.enabled = true;
                    mainCameraON = false;

                    // ★追加
                    // 主観カメラの場合、照準器をオンにする。
                    //aimImage.SetActive(true);
                }

                else if (input==true && mainCameraON == false)
                {
                    mainCamera.enabled = true;
                    subCamera.enabled = false;
                    mainCameraON = true;

                    // ★追加
                    // 客観カメラの場合、照準器をオフにする。
                //    aimImage.SetActive(false);
                }
            }


        }

    }
}