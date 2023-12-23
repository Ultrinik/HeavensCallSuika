using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    GameObject[] balls;
    GameObject balls_parent;

    private void Start()
    {
        balls_parent = BallManager.Instance.balls_parent;
        balls = BallManager.Instance.balls;
    }

    void Update()
    {
        OnMouseClick();
    }


    void OnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            int randomIndex = Random.Range(0, balls.Length);
            GameObject randomBall = balls[randomIndex];

            Instantiate(randomBall, mousePosition, Quaternion.identity, balls_parent.transform);
        }
    }
}
