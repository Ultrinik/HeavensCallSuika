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

    public GameObject score_go;

    private void Update()
    {
        text.text = currentScore.ToString();
        if (!GameManager.Instance.inGame)
        {
            text.color = Color.red;
        }
    }

    public void AddScore(int level, Vector3 position)
    {
        int newScore = ScoreManager.GetScore(level);
        currentScore += newScore;


        GameObject score = Instantiate(score_go, position, Quaternion.identity);
        score.transform.position -= Vector3.forward;
        TextMeshProUGUI scoreText = score.GetComponentInChildren<TextMeshProUGUI>();
        scoreText.text = newScore.ToString();
        Destroy(score, 1);
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
