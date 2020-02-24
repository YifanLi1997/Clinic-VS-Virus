using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    AudioSource[] m_audioSources;

    private void Start()
    {
        m_audioSources = FindObjectsOfType<AudioSource>();

        foreach (var m_audioSource in m_audioSources)
        {
            m_audioSource.volume = PlayerPrefsController.GetVolume();
        }
    }

}
