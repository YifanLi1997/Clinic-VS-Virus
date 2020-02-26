using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject trueWinnerPanel;
    [SerializeField] GameObject winWithoutFreedonPanel;
    [SerializeField] GameObject clickBlocker;

    [SerializeField] Boss realBoss;
    [SerializeField] LevelProgress levelProgress;

    [SerializeField] int numberOfAttackers = 0;
    AudioSource[] m_audioSources;

    private void Update()
    {
        numberOfAttackers = FindObjectsOfType<Attacker>().Length;

        if (realBoss.GetIsActive())
        {
            if (realBoss.GetIsDead() && numberOfAttackers == 0)
            {
                StartCoroutine(WaitAndEnd(trueWinnerPanel, 3f));
            }
        }
        else
        {
            if (levelProgress.GetIsLevelProgressCompleted() )
            {
                StartCoroutine(WaitAndEnd(winWithoutFreedonPanel, 1f));
            }
        }
    }

    IEnumerator WaitAndEnd(GameObject panel, float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);

        m_audioSources = FindObjectsOfType<AudioSource>();

        foreach (var m_audioSource in m_audioSources)
        {
            m_audioSource.mute = true;
        }

        panel.SetActive(true);
        panel.GetComponent<AudioSource>().volume = PlayerPrefsController.GetVolume();
        clickBlocker.SetActive(true);
        Time.timeScale = 0;
    }
}
