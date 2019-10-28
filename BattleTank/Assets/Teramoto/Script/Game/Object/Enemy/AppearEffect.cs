using UnityEngine;
using System.Collections;
 
public class AppearEffect : MonoBehaviour
{

    //　出現させるエフェクト
    [SerializeField]
    private GameObject effectObject=null;

    // Use this for initialization
    void Start()
    {
        //　ゲームオブジェクト登場時にエフェクトをインスタンス化
        var instantiateEffect = GameObject.Instantiate(effectObject, transform.position, Quaternion.identity) as GameObject;
        Destroy(instantiateEffect, 2.0f);
    }
}