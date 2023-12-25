using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{

    public GameObject _particles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.LoseGame();

            Vector2 position = collision.gameObject.transform.position;
            GameObject particles = Instantiate(_particles, new Vector3(position.x, position.y, 1), Quaternion.Euler(-90, 0, 0));
            particles.transform.localScale *= 0.3f;
            
        }
    }
}
