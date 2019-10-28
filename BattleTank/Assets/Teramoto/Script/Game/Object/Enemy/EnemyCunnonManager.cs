using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCunnonManager : MonoBehaviour
{
    GameObject gameClearManager;
    GameClearController script;
    BoxCollider boxCol;
    EnemyRadar rader;

    // Start is called before the first frame update
    void Start()
    {
        boxCol = GetComponent<BoxCollider>();
        rader = GetComponent<EnemyRadar>();
        
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
            boxCol.enabled = false;
            rader.enabled = false;
        }
        else
        {
            boxCol.enabled = true;
            rader.enabled = true;
        }

    }

}
