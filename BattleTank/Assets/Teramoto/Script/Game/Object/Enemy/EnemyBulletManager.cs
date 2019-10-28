using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletManager : MonoBehaviour
{
    EnemyRadar rader;
    EnemyCunnonBaseShot shot;
    GameObject gameClearManager;
    GameClearController script;

    // Start is called before the first frame update
    void Start()
    {
        gameClearManager = GameObject.Find("GameManager");
        script = gameClearManager.GetComponent<GameClearController>();
        rader = GetComponent<EnemyRadar>();
        shot = GetComponent<EnemyCunnonBaseShot>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (script.GetAnimeFlag() == true)
        {
            rader.enabled = false;
            shot.enabled = false;
        }
        else
        { 
            shot.enabled = true;
            rader.enabled = true;
        }

    }

}
