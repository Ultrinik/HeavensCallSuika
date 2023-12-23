using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public AudioClip resetSound;

    public void RestartGame()
    {
        MusicManager.PlaySound(resetSound, 1);

        SceneManager.LoadScene("SampleScene");
    }
}
