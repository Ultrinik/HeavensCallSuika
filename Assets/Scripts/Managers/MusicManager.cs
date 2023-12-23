using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private void InitAwake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            gameObject.transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }

    [HideInInspector]
    public AudioSource audioSource, sfxAudioSource;

    private void Awake()
    {
        InitAwake();

        AudioSource[] audioSources = GetComponents<AudioSource>();
        audioSource = audioSources[0];
        sfxAudioSource = audioSources[1];
    }
}
