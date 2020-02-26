using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreedomOfSpeech : MonoBehaviour
{

    GameObject m_fakeBoss;
    GameObject m_realBoss;

    private void Start()
    {
        m_realBoss = GameObject.Find("Real Boss");
        m_fakeBoss = GameObject.Find("Fake Boss");

        GetComponent<AudioSource>().volume = PlayerPrefsController.GetVolume();
    }

    public void TriggerBosses()
    {
        FakeBossOut();

        StartCoroutine(WaitAndRealBossIn());
    }

    IEnumerator WaitAndRealBossIn()
    {
        if (!m_realBoss.GetComponent<Boss>().GetIsActive())
        {
            m_realBoss.GetComponent<Animator>().SetBool("isWalking", true);

            yield return new WaitForSeconds(2f);

            m_realBoss.GetComponent<AudioSource>().mute = false;
            FindObjectOfType<LevelProgress>().SetIsLevelProgressCompleted(true);
        }
    }

    private void FakeBossOut()
    {
        m_fakeBoss.GetComponent<Animator>().SetTrigger("FakeBossOut");
        m_fakeBoss.GetComponent<AudioSource>().mute = true;
    }
}
