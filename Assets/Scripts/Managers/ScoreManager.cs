using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private void Awake()
    {
        Instance = this;
    }


    public TextMeshProUGUI text;
    int currentScore = 0;

    private void Update()
    {
        text.text = currentScore.ToString();
    }

    public void AddScore(int level)
    {
        int newScore = ScoreManager.GetScore(level);
        currentScore += newScore;
    }

    public static int GetScore(int level)
    {
        int prevScore = 0;
        int trueLevel = level + 1;

        for (int i=1; i < trueLevel; i++)
        {
            prevScore = i + prevScore;
        }

        return trueLevel + prevScore;
    }
}
