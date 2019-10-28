using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] wayPoints;
    int cur = 0;
    public float speed = 0.5f;

    void FixedUpdate()
    {

        // 現在位置が中継ポイントの位置と異なるならば（条件）
        if (transform.position != wayPoints[cur].position)
        {

            Vector3 p = Vector3.MoveTowards(transform.position, wayPoints[cur].position, speed);
            GetComponent<Rigidbody>().MovePosition(p);

            // 顔の向き
            transform.LookAt(wayPoints[cur].position);

        }
        else
        {

            // ★（重要テクニック）
            // 配列の中の順序を１つずつ繰り上げていくテクニック（最後はまた０に戻る。）
            cur = (cur + 1) % wayPoints.Length;
        }
    }
}
