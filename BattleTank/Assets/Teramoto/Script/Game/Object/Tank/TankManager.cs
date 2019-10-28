
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider boxCol;
    TankMovement move;
    TankHealth health;

    GameObject gameClearManager;
    GameClearController script;

    GameObject trap;
    friezeTrap trapScript;


    GameObject cunnonBase;
    Bullet shot;


    // Start is called before the first frame update
    void Start()
    {
       rb =  GetComponent<Rigidbody>();
       boxCol= GetComponent<BoxCollider>();
       move =  GetComponent<TankMovement>();
       health = GetComponent<TankHealth>();


        gameClearManager = GameObject.Find("GameManager");
        script = gameClearManager.GetComponent<GameClearController>();

        cunnonBase = GameObject.Find("TurretPos");
        shot = cunnonBase.GetComponent<Bullet>();

    }


    void FixedUpdate()
    {
        if(script.GetAnimeFlag()==true)
        {
            boxCol.enabled = false;
            move.enabled = false;
            rb.isKinematic = true;
        }
        else
        {
            boxCol.enabled = true;
            move.enabled = true;
            rb.isKinematic = false;
        }

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShell")
        {
            if (!script.GetAnimeFlag())
            {
                health.Damage(other);
            }
            Destroy(other.gameObject);
        }


    }

}
