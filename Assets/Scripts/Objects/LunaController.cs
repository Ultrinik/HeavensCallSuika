using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaController : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderes;
    public Sprite[] sprites;

    public AudioClip dropSound;
    private void Update()
    {
        ChangePlanet(GameManager.Instance.currentBallIndex);

        if (!GameManager.Instance.inGame)
        {
            SetLose();
        }
    }

    public void ChangePlanet(int ballType)
    {
        spriteRenderes[1].sprite = BallManager.Instance.sprites[ballType];
    }

    public void SetReady()
    {
        spriteRenderes[0].sprite = sprites[2];
        spriteRenderes[1].enabled = true;
        spriteRenderes[2].sprite = sprites[0];
    }
    public void SetDrop()
    {
        MusicManager.PlaySound(dropSound, 1);

        spriteRenderes[0].sprite = sprites[3];
        spriteRenderes[1].enabled = false;
        spriteRenderes[2].sprite = sprites[1];
    }

    public void SetLose()
    {
        spriteRenderes[0].enabled = false;
        spriteRenderes[1].enabled = false;
        spriteRenderes[2].sprite = sprites[4];
    }
}
