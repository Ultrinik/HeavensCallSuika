using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public AudioClip resetSound;

    public void RestartGame()
    {
        if (GameManager.sfxEnabled)
        {
            MusicManager.Instance.sfxAudioSource.PlayOneShot(resetSound);
        }

        SceneManager.LoadScene("SampleScene");
    }
}
