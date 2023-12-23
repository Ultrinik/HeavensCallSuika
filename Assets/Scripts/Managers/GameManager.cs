using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    [HideInInspector]
    public bool inGame = true;

    [HideInInspector]
    public int currentBallIndex;
    [HideInInspector]
    public int nextBallIndex;

    Sprite[] ballSprites;
    public Image image;

    [HideInInspector]
    public float maxHeight = 0.0f;

    public GameObject bottomWall;

    public static bool sfxEnabled = true;

    private void Start()
    {
        ballSprites = BallManager.Instance.sprites;

        currentBallIndex = BallManager.GetRandomBall();
        nextBallIndex = BallManager.GetRandomBall();
    }

    void Update()
    {
        UpdateMaxHeight();
        image.sprite = ballSprites[nextBallIndex];

    }

    void UpdateMaxHeight()
    {
        float max = 0;
        for(int i=0; i<BallManager.Instance.balls_parent.transform.childCount; i++)
        {
            GameObject ball = BallManager.Instance.balls_parent.transform.GetChild(i).gameObject;
            if (ball.GetComponent<BallLogic>().landed)
            {
                float y = ball.transform.position.y;
                float r = ball.GetComponent<CircleCollider2D>().radius * ball.transform.localScale.x;

                float total = y + r - bottomWall.transform.position.y;
                max = Mathf.Max(max, total);
            }
        }
        max /= 20f;

        maxHeight = Mathf.Lerp(maxHeight, max, Time.deltaTime);
    }

    public void LoseGame()
    {
        if (inGame)
        {
            inGame = false;
        }
    }
}
