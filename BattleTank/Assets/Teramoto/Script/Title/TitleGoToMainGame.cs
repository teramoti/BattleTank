using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;
//タイトルからMainに飛ぶ処理
public class TitleGoToMainGame : MonoBehaviour
{
    public GameObject effectPrefab;

    int timer;
    bool IsSceneFlag;

    bool IsPress;

    bool IsKey;

    bool sIstutorial;

    int slot=0;
    //移動音
    public AudioClip sound;

    private AudioSource audioSource;

    public GameObject tutorialOn;
    public GameObject tutorialOff;

    public GameObject keyBoardUI;
    public GameObject controllerUI;
    private bool pauseGame = false;

    GameObject join;

    JoinController script;

    bool IsJoinController;

    float turnInputValue;

    public bool Istutorial { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        IsSceneFlag = false;
        IsPress = false;
        turnInputValue = 1;
    }

    // Update is called once per frame
    void Update()
    {
        join = GameObject.Find("GameManager");
        script = join.GetComponent<JoinController>();

        IsKey = Input.GetButtonDown("Fire2");


        if (IsKey==true)
        {
            IsPress = true;
            // 効果音を出す。
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }


        if(IsPress)
        {
            ChangeController();
            timer++;
            print(turnInputValue);

        }
        if (timer < 180 && IsPress==true)
        {
            //光るエフェクト
            //GameObject effect = Instantiate(effectPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            //Destroy(effect, 2.0f);
        }
        if (timer > 180)
        {
            IsSceneFlag = true;
        }

        if (IsSceneFlag==true)
        {
            SceneManager.LoadScene("Main");
        }

    }

    public bool GetPushFlag()
    {
        return IsPress;
    }

    public bool GetTutorialFlag()
    {
        return Istutorial;
    }
    void ChangeController()
    {

        IsJoinController = script.GetController();

        if (IsJoinController == true)
        {
            //コントローラーがあったら
            controllerUI.SetActive(true);
            keyBoardUI.SetActive(false);

        }
        else
        {
            //コントローラーがないなら
            keyBoardUI.SetActive(true);
            controllerUI.SetActive(false);

        }
    }
}
