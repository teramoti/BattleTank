using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    private GameObject nearObj;         //最も近いオブジェクト
    private float searchTime = 0;    //経過時間


    public GameObject target;

    public float shotSpeed=600;

    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //最も近かったオブジェクトを取得
        nearObj = serchTag(gameObject, "Player");
    }

    void Update()
    {
        if (searchTime >= 1.0f)
        {
            //最も近かったオブジェクトを取得
           // nearObj = serchTag(gameObject, "Player");
            CorrectBaseHeight();
            //経過時間を初期化
            searchTime = 0;
        }

        // ターゲットの位置を目的地に設定する。
        agent.destination = nearObj.transform.position;
    }
    private void CorrectBaseHeight()
    {
        NavMeshHit navhit;
        if (NavMesh.SamplePosition(transform.position, out navhit, 10f, NavMesh.AllAreas))
        {
            Ray r = new Ray(navhit.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit, 10f, LayerMask.GetMask("Level")))
            {
                _nav.baseOffset = -hit.distance;
            }
        }
    }

    NavMeshAgent _nav;

    

    GameObject serchTag(GameObject nowObj, string tagName)
    {
        float tmpDis = 0;           //距離用一時変数
        float nearDis = 0;          //最も近いオブジェクトの距離
        //string nearObjName = "";    //オブジェクト名称
        GameObject targetObj = null; //オブジェクト

        //タグ指定されたオブジェクトを配列で取得する
        foreach (GameObject obs in GameObject.FindGameObjectsWithTag(tagName))
        {
            //自身と取得したオブジェクトの距離を取得
            tmpDis = Vector3.Distance(obs.transform.position, nowObj.transform.position);

            //オブジェクトの距離が近いか、距離0であればオブジェクト名を取得
            //一時変数に距離を格納
            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                //nearObjName = obs.name;
                targetObj = obs;
            }

        }
        //最も近かったオブジェクトを返す
        return targetObj;

    }
}