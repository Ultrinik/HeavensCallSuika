using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaController : MonoBehaviour
{
    public SpriteRenderer[] spriteRenderes;
    public Sprite[] sprites;

    private void Update()
    {
        ChangePlanet(GameManager.Instance.currentBallIndex);
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
        spriteRenderes[0].sprite = sprites[3];
        spriteRenderes[1].enabled = false;
        spriteRenderes[2].sprite = sprites[1];
    }
}
