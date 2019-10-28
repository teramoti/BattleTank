using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCunnonChaseManager : MonoBehaviour
{
    GameObject gameClearManager;
    GameClearController script;
    BoxCollider boxCol;

   public EnemyRadar rader;
    
    GameObject cunnonBase;
    
    public EnemyCunnonBaseShot shot;

    EnemyChase chase;
    // Start is called before the first frame update
    void Start()
    {
        chase = GetComponent<EnemyChase>();
        boxCol = GetComponent<BoxCollider>();


        gameClearManager = GameObject.Find("GameManager");
        script = gameClearManager.GetComponent<GameClearController>();

    }


    void FixedUpdate()
    {
        if (script.GetAnimeFlag() == true)
        {
            rader.enabled = false;
            boxCol.enabled = false;
            chase.enabled = false;
            shot.enabled = false;
        }
        else
        {
            rader.enabled = true;
            shot.enabled = true;
            boxCol.enabled = true;
            chase.enabled = true;
        }

    } 
    // Update is called once per frame
    void Update()
    {

    }

}
