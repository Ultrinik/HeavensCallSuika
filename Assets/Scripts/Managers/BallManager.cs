using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static BallManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public GameObject balls_parent;
    public GameObject[] balls;
    public Sprite[] sprites;

    public GameObject[] particles;

    public static void FuseBalls(GameObject ball1, GameObject ball2, int ballType)
    {
        Vector2 position = (ball1.transform.position + ball2.transform.position) / 2;

        GameObject randomBall = Instance.balls[ballType];
        GameObject newBall = Instantiate(randomBall, position, Quaternion.identity, Instance.balls_parent.transform);

        Vector2 velocity = (ball1.GetComponent<Rigidbody2D>().velocity + ball2.GetComponent<Rigidbody2D>().velocity) / 3;
        newBall.GetComponent<Rigidbody2D>().velocity = velocity;

        ScoreManager.Instance.AddScore(ballType);

        GameObject particles = Instantiate(Instance.particles[ballType], position, Quaternion.identity, newBall.transform);
        particles.transform.position = new Vector3(position.x, position.y, 1);
        particles.transform.localScale *= 0.5f;
        Destroy(particles, 1);

        Destroy(ball1);
        Destroy(ball2);
    }

    public static int GetRandomBall()
    {
        return Random.Range(0, 5);
    }
}
