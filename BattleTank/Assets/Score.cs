using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    private int score;
    public static int FinalScore = 0;

    public Text label;

    void Update()
    {
        label.text = ""+score;
        FinalScore = score;
    }
    // 表示する値



    public void AddScore(int num)
    {
        score += num;
    }

    public static int GetLastScore()
    {
        return FinalScore;
    }
}