using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResultGoToTitle : MonoBehaviour
{

    bool IsPush;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsPush = Input.GetButtonDown("Fire2");
     if (IsPush==true)
        {
            SceneManager.LoadScene("Title");
        }   
    }
}
