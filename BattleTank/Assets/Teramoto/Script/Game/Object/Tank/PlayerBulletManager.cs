using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : MonoBehaviour
{
    GameObject gameClearManager;
    GameClearController script;

    Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Bullet>();
        gameClearManager = GameObject.Find("GameManager");
        script = gameClearManager.GetComponent<GameClearController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        if (script.GetAnimeFlag() == true)
        {
            bullet.enabled = true;
        }
        else
        {
            bullet.enabled = true;
        }

    }

}
