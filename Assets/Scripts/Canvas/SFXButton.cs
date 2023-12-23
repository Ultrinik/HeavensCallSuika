using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXButton : MonoBehaviour
{
    int state = 0;

    private void Start()
    {
        CheckInitState();
    }

    public void CheckInitState()
    {
        bool active = GameManager.sfxEnabled;

        if (!active)
        {
            state = 1;
            GetComponent<SwitchIcon>().OnClick();
        }
    }

    public void OnClick()
    {
        if (state == 0)
        {
            state = 1;
            GameManager.sfxEnabled = false;
        }
        else
        {
            state = 0;
            GameManager.sfxEnabled = true;
        }
    }
}
