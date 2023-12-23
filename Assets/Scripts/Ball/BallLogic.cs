using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    [HideInInspector]
    public bool flaggedToFuse = false;

    public int ballType = -1;

    public bool landed = false;

    private void Start()
    {
        Invoke("SetLanded", 1);

        AudioSource audioSource = GetComponentInChildren<AudioSource>();
        if (audioSource.enabled && GameManager.sfxEnabled)
        {
            GetComponentInChildren<AudioSource>().Play();
        }
    }

    public void SetLanded()
    {
        landed = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Ball"))
        {
            BallLogic otherBall = collider.GetComponent<BallLogic>();
            if (!flaggedToFuse && !otherBall.flaggedToFuse && otherBall.ballType == ballType && ballType < 10)
            {
                flaggedToFuse = true;
                otherBall.flaggedToFuse = true;

                BallManager.FuseBalls(gameObject, collider, ballType+1);
            }
        }
    }

}
