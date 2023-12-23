using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public LunaController lunaController;
    GameObject luna_go;

    public GameObject wall;
    float margin = 0.5f;

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
        if (Input.GetMouseButtonDown(0) && cooldown <= 0 && GameManager.Instance.inGame)
        {
            lunaController.SetDrop();

            GameObject currentBall = BallManager.Instance.balls[GameManager.Instance.currentBallIndex];
            Vector3 position = luna_go.transform.position + Vector3.right * Random.Range(-1f,1f) * 0.01f;
            GameObject newBall = Instantiate(currentBall, position, Quaternion.identity, BallManager.Instance.balls_parent.transform);
            newBall.GetComponentInChildren<AudioSource>().enabled = false;

            GameManager.Instance.currentBallIndex = GameManager.Instance.nextBallIndex;
            GameManager.Instance.nextBallIndex = BallManager.GetRandomBall();

            cooldown = 0.75f;
            lunaController.Invoke("SetReady", cooldown);
        }
    }

   void MoveLuna()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.y = 3.75f;
        mousePosition.z = 0;

        float max_X = wall.transform.position.x - margin;
        float current_X = Mathf.Abs(mousePosition.x);

        float new_X = Mathf.Min(max_X, current_X);

        mousePosition.x = Mathf.Sign(mousePosition.x) * new_X;
        luna_go.transform.position = mousePosition;
    }
}
