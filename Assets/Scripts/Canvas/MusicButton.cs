using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : MonoBehaviour
{
    int state = 0;

    private void Start()
    {
        CheckInitState();
    }

    public void CheckInitState()
    {
        bool active = MusicManager.Instance.audioSource.volume > 0;

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
            MusicManager.Instance.audioSource.volume = 0f;
        }
        else
        {
            state = 0;
            MusicManager.Instance.audioSource.volume = 0.85f;
        }
    }
}
