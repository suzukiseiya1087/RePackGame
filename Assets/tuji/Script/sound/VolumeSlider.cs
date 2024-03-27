using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    private void Start()
    {
    }

    public void SetBGMVolume(float volume)
    {
        SoundManager.instance.SetBGMVolume(volume);


    }
}