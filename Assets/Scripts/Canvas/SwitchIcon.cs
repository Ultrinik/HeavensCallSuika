using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchIcon : MonoBehaviour
{
    public Sprite spriteA, spriteB;
    public int state = 0;

    public Image image;

    public void OnClick()
    {
        if (state == 0)
        {
            state = 1;
            image.sprite = spriteB;
        }
        else
        {
            state = 0;
            image.sprite = spriteA;
        }
    }
}
