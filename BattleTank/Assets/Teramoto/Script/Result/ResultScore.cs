using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultScore : MonoBehaviour
{
    int score;

    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        int score = Score.GetLastScore();
        print(score);
        text.text = "" + Score.GetLastScore();

    }

    // Update is called once per frame
    void Update()
    {
    }
}
