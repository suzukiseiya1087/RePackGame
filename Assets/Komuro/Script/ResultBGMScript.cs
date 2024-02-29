using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultBGMScript : MonoBehaviour
{
    AudioSource m_audioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Nagadomo")
        {
            m_audioSource.Stop();
        }
        else if (m_audioSource.isPlaying == false)
        {
            m_audioSource.Play();
        }
    }
}
