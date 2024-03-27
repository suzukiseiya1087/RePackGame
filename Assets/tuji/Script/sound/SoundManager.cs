using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance;

    [SerializeField] AudioSource bgmAudioSource;
    //[SerializeField] Slider slider;

    private void Start()
    {
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetBGMVolume(float volume)
    {
        //slider.value = volume;

        bgmAudioSource.volume = volume;

    }
}