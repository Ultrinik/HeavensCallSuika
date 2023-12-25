using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    [HideInInspector]
    public bool flaggedToFuse = false;

    public int ballType = -1;

    [HideInInspector]
    public bool landed = false;

    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;

    Rigidbody2D rb;

    bool inAnimationFlag = false;

    private void Start()
    {
        Invoke("SetLanded", 1);

        AudioSource audioSource = GetComponentInChildren<AudioSource>();
        if (audioSource.enabled && GameManager.sfxEnabled)
        {
            GetComponentInChildren<AudioSource>().Play();
        }

        rb = GetComponent<Rigidbody2D>();

        if (GameManager.onlyCircles)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    public void SetLanded()
    {
        landed = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool collideFlag = true;
        float hurtSpeed = 3;

        float hitSpeed = rb.velocity.magnitude;

        GameObject collider = collision.gameObject;
        if (collider.CompareTag("Ball"))
        {
            BallLogic otherBall = collider.GetComponent<BallLogic>();
            if (!flaggedToFuse && !otherBall.flaggedToFuse && otherBall.ballType == ballType)
            {
                flaggedToFuse = true;
                otherBall.flaggedToFuse = true;

                BallManager.FuseBalls(gameObject, collider, ballType+1);
                collideFlag = false;
            }

            if (collideFlag)
            {
                if (hitSpeed > hurtSpeed)
                {
                    otherBall.GetImpactHit();
                }
            }
        }

        if (collideFlag)
        {
            float minSpeed = 2.5f;
            if (hitSpeed > minSpeed)
            {
                float volume = Mathf.Min(1, rb.velocity.magnitude / minSpeed) * 0.5f;
                MusicManager.PlaySound(BallManager.Instance.collideSound, volume);
            }
        }

        if (hitSpeed > hurtSpeed)
        {
            GetImpactHit();
        }
    }


    public void GetImpactHit()
    {
        if (!inAnimationFlag)
        {
            inAnimationFlag = true;

            SetHurtFace();
            Invoke("SetAngryFace", 1);
            Invoke("SetNormalFace", 1.5f);
        }
    }

    void SetNormalFace()
    {
        spriteRenderer.sprite = sprites[0];
        inAnimationFlag = false;
    }
    void SetHurtFace()
    {
        spriteRenderer.sprite = sprites[1];
    }
    void SetAngryFace()
    {
        spriteRenderer.sprite = sprites[2];
    }

}
