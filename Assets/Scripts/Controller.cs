using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public LunaController lunaController;
    GameObject luna_go;

    public GameObject wall;
    float[] marginArr = new float[] {0.36f, 0.52f, 0.61f,  0.651f, 0.733f, 0.91f, 1.1f, 1.19f, 1.688f, 1.91f, 2.26f};

    float cooldown = 0;

    private void Start()
    {
        luna_go = lunaController.gameObject;
    }

    private void Update()
    {
        OnMouseClick();
        MoveLuna();
        CooldownUpdate();
    }

    void CooldownUpdate()
    {
        cooldown -= Time.deltaTime;
    }

    void OnMouseClick()
    {
        if (Input.GetMouseButtonUp(0) && cooldown <= 0 && GameManager.Instance.inGame)
        {
            float mousePositionX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            float margin = marginArr[GameManager.Instance.currentBallIndex];
            float max_X = wall.transform.position.x + margin;
            if (-max_X <= mousePositionX && mousePositionX <= max_X)
            {
                lunaController.SetDrop();

                GameObject currentBall = BallManager.Instance.balls[GameManager.Instance.currentBallIndex];
                Vector3 position = luna_go.transform.position + Vector3.right * Random.Range(-1f, 1f) * 0.01f;
                position.z = 0;
                GameObject newBall = Instantiate(currentBall, position, Quaternion.identity, BallManager.Instance.balls_parent.transform);
                newBall.GetComponentInChildren<AudioSource>().enabled = false;

                GameManager.Instance.currentBallIndex = GameManager.Instance.nextBallIndex;
                GameManager.Instance.nextBallIndex = BallManager.GetRandomBall();

                cooldown = 0.75f;
                lunaController.Invoke("SetReady", cooldown);
            }
        }
    }

   void MoveLuna()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = 3.91f;
        mousePosition.z = -5;

        float margin = marginArr[GameManager.Instance.currentBallIndex];
        float max_X = wall.transform.position.x - margin;
        float current_X = Mathf.Abs(mousePosition.x);

        float new_X = Mathf.Min(max_X, current_X);

        mousePosition.x = Mathf.Sign(mousePosition.x) * new_X;
        luna_go.transform.position = Vector3.Lerp(luna_go.transform.position, mousePosition, Time.deltaTime*15);
    }
}
