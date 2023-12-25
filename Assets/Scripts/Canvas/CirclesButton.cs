using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CirclesButton : MonoBehaviour
{
    int state = 0;

    public TextMeshProUGUI text;

    private void Start()
    {
        CheckInitState();
    }

    public void CheckInitState()
    {
        bool active = GameManager.onlyCircles;

        if (active)
        {
            state = 1;
            text.text = "Circle mode\n(on)";
        }
        else
        {
            state = 0;
            text.text = "Circle mode\n(off)";
        }
    }

    public void OnClick()
    {
        if (state == 1)
        {
            state = 0;
            GameManager.onlyFlagCircles = false;
            text.text = "Circle mode\n(off)";
        }
        else
        {
            state = 1;
            GameManager.onlyFlagCircles = true;
            text.text = "Circle mode\n(on)";
        }
    }
}
