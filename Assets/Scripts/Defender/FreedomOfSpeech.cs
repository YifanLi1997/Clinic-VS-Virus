using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreedomOfSpeech : MonoBehaviour
{
    [Tooltip("Time (in seconds) before destroying virus spawners after real boss comes")]
    [SerializeField] float waitingTime = 24f;

    GameObject m_fakeBoss;
    GameObject m_realBoss;
    GameObject m_virusSpawner;

    private void Start()
    {
        m_realBoss = GameObject.Find("Real Boss");
        m_fakeBoss = GameObject.Find("Fake Boss");
        m_virusSpawner = GameObject.Find("Virus Spawner");

        GetComponent<AudioSource>().volume = PlayerPrefsController.GetVolume();
    }

    public void TriggerBosses()
    {
        FakeBossOut();

        StartCoroutine(WaitAndRealBossIn());

        Destroy(m_virusSpawner, waitingTime);
    }

    IEnumerator WaitAndRealBossIn()
    {
        if (!m_realBoss.GetComponent<Boss>().GetIsActive())
        {
            m_realBoss.GetComponent<Animator>().SetBool("isWalking", true);

            yield return new WaitForSeconds(2f);

            m_realBoss.GetComponent<AudioSource>().mute = false;
        }
    }

    private void FakeBossOut()
    {
        m_fakeBoss.GetComponent<Animator>().SetTrigger("FakeBossOut");
        m_fakeBoss.GetComponent<AudioSource>().mute = true;
    }
}
