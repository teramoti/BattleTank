
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// オブジェクトを点滅させるクラス
public class TitleBlinker : MonoBehaviour
{


    public Image image;
     int timer;
    [SerializeField]
    private int flashtime=10;

    void Start()
    {
        timer = 0;
    }
    void Update()
    {
        timer++;
        if (timer % flashtime == 0)
        {
            image.enabled = !image.enabled;

        }

        if(timer>6000)
        {
           timer = 0;
        }
    }
}