using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject effectPrefab;

    public GameObject breakObjecteffectPrefab;
    public int objectHP;


    GameObject score;

    [SerializeField]
    private int enemySocre=0; 
    Score script;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            // ★★追加
            // オブジェクトのHPを１ずつ減少させる。
            objectHP -= 1;

            // ★★追加
            // もしもHPが0よりも大きい場合には（条件）
            if (objectHP > 0)
            {
                Destroy(other.gameObject);
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);
            }
            else
            {

                Destroy(other.gameObject);

                // もう１種類のエフェクを発生させる。
                GameObject effect2 = Instantiate(breakObjecteffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);


                score = GameObject.Find("Canvas");
                script = score.GetComponent<Score>();
                script.AddScore(enemySocre);
                Destroy(this.gameObject);
            }
        }
    }
}