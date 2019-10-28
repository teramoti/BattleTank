using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShellItem : MonoBehaviour
{
    public AudioClip getSound;
    public GameObject effectPrefab;
    [SerializeField]
    private Bullet ss=null;
   // [SerializeField]
   // private int reward = 5; // 弾数をいくつ回復させるかは自由に決定

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // （重要ポイント）
            // Find()メソッドは、「名前」でオブジェクトを探し特定します。
            // 「ShotShell」オブジェクトを探し出して、それに付いている「ShotShell」スクリプト（component）のデータを取得。
            // 取得したデータを「ss」の箱の中に入れる。
            ss = GameObject.Find("TurretPos").GetComponent<Bullet>();

            //  ShotShellスクリプトの中に記載されている「AddShellメソッド」を呼び出す。
            // rewardで設定した数値分だけ弾数が回復する。
          // ss.AddShell(reward);

            // アイテムを画面から削除する。
            Destroy(gameObject);

            // アイテムゲット音を出す。
            // MainCameraのタグが付いているカメラの側で音を発生させる。
            AudioSource.PlayClipAtPoint(getSound, Camera.main.transform.position);

            // アイテムゲット時にエフェクトを発生させる。
            //GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);

            // エフェクトを0.5秒後に消す。
            //Destroy(effect, 0.5f);
        }
    }
}