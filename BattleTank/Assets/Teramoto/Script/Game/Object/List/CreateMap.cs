using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateMap : MonoBehaviour
{
    private string musicName= "test"; // 読み込む譜面の名前

    [SerializeField]//マップデータのプレハブ変数
    private GameObject[] mapDatePrefab = null;

    // [HideInInspector]//拡大率
    public float scaling = 1.0f;

    //幅
    public float scal = 0.0f;


    bool IsEnemyAriveFlag;
    enum BlockNumber : int
    {
        Prefab_0,
        Prefab_1,
        Prefab_2,
        Prefab_3,
        Prefab_4,
        Prefab_5,
        Prefab_6,
        Prefab_7,
        Prefab_8,
        Prefab_9,
        Prefab_10,
    };

    const int prefab_0 = (int)BlockNumber.Prefab_0;
    const int prefab_1 = (int)BlockNumber.Prefab_1;
    const int prefab_2 = (int)BlockNumber.Prefab_2;
    const int prefab_3 = (int)BlockNumber.Prefab_3;
    const int prefab_4 = (int)BlockNumber.Prefab_4;
    const int prefab_5 = (int)BlockNumber.Prefab_5;
    const int prefab_6 = (int)BlockNumber.Prefab_6;
    const int prefab_7 = (int)BlockNumber.Prefab_7;
    const int prefab_8 = (int)BlockNumber.Prefab_8;
    const int prefab_9 = (int)BlockNumber.Prefab_9;
    const int prefab_10 = (int)BlockNumber.Prefab_10;

    GameObject tank;

    private TextAsset csvFile; // CSVファイル

    private void Start()
    {
        IsEnemyAriveFlag = true;

        musicName = "test";

        tank = GameObject.Find("Tank");

    }

    private void Update()
    {
        if (IsEnemyAriveFlag == true)
        {
            Make(0);
        }
    }

    public void Make(int stagenum)
    {

        Vector3 sub = Vector3.zero;
        string a = musicName + stagenum;

        csvFile = Resources.Load(a) as TextAsset;
        StringReader reader = new StringReader(csvFile.text);

        print("呼び出しは"+a+"です");



        while (reader.Peek() > -1)
        {
            // カンマ区切りで読み込んで行ごとにマップを作成
            string line = reader.ReadLine();
            string[] values = line.Split(',');

            foreach (string value in values)
            {
                // 読み込んだからマップを作成
                int integer = int.Parse(value);

                if (integer >= 0 && integer < mapDatePrefab.Length)
                {
                    //オブジェクトを一個ずつ
                    GameObject obj = null;
                    switch (integer)
                    {
                        //prefab_0だったら
                        case prefab_0:
                            if (mapDatePrefab[prefab_0] != null)
                            {
                                obj = null;
                                break;
                            }
                            break;
                        //prefab_1だったら
                        case prefab_1:
                            if (mapDatePrefab[prefab_1] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }
                            break;
                        //prefab_2だったら
                        case prefab_2:
                            if (mapDatePrefab[prefab_2] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }
                            break;

                        //prefab_3だったら
                        case prefab_3:
                            if (mapDatePrefab[prefab_3] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }
                            break;

                        //prefab_4だったら
                        case prefab_4:
                            if (mapDatePrefab[prefab_4] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }
                            break;

                        //prefab_5だったら
                        case prefab_5:
                            if (mapDatePrefab[prefab_5] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }
                            break;

                        //prefab_1だったら
                        case prefab_6:
                            if (mapDatePrefab[prefab_6] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }
                            break;
                        //prefab_2だったら
                        case prefab_7:
                            if (mapDatePrefab[prefab_7] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }
                            break;

                        //prefab_3だったら
                        case prefab_8:
                            if (mapDatePrefab[prefab_8] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }
                            break;

                        //prefab_4だったら
                        case prefab_9:
                            if (mapDatePrefab[prefab_9] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }
                            break;

                        //prefab_5だったら
                        case prefab_10:
                            if (mapDatePrefab[prefab_10] != null)
                            {
                                obj = Instantiate(mapDatePrefab[integer], transform);
                                break;
                            }

                            break;

                        //空白
                        default:
                            break;
                    }

                    if (obj != null)
                    {

                        obj.transform.position = new Vector3(transform.position.x+sub.x, transform.position.y ,transform.position.z + sub.z);
                        obj.transform.localScale *= scaling;
                    }
                }

                sub.x += scaling * scal;
            }
            sub.x = 0;
            sub.z -= scaling * scal;

            //プレイヤーの位置変更
            tank.transform.position = new Vector3(-125,2,-125);

            IsEnemyAriveFlag = false;
        }
    }

    public void Remove()
    {
        for (var num = 0; num < transform.childCount; num++)
        {
            Destroy(transform.GetChild(num).gameObject);
        }
    }
}
