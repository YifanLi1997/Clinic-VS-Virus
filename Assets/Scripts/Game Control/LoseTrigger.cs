using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] Boss realBoss;
    [SerializeField] GameObject loserWithFreedomPanel;
    [SerializeField] GameObject loserPanel;

    AudioSource[] m_audioSources;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_audioSources = FindObjectsOfType<AudioSource>();

        foreach (var m_audioSource in m_audioSources)
        {
            m_audioSource.mute = true;
        }

        if (realBoss.GetIsActive())
        {
            loserWithFreedomPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            loserPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
