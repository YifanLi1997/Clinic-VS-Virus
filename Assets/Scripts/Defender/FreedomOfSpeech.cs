using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreedomOfSpeech : MonoBehaviour
{
    [Tooltip("Time (in seconds) before destroying virus spawners after real boss comes")]
    [SerializeField] float waitingTime = 24f;

    GameObject m_FakeBoss;
    GameObject m_RealBoss;
    GameObject m_VirusSpawner;

    private void Start()
    {
        m_RealBoss = GameObject.Find("Real Boss");
        m_FakeBoss = GameObject.Find("Fake Boss");
        m_VirusSpawner = GameObject.Find("Virus Spawner");
    }

    public void TriggerBosses()
    {
        FakeBossOut();

        StartCoroutine(WaitAndRealBossIn());

        Destroy(m_VirusSpawner, waitingTime);
    }

    IEnumerator WaitAndRealBossIn()
    {
        if (!m_RealBoss.GetComponent<Boss>().GetIsActive())
        {
            m_RealBoss.GetComponent<Animator>().SetBool("isWalking", true);

            yield return new WaitForSeconds(2f);

            m_RealBoss.GetComponent<AudioSource>().mute = false;
        }
    }

    private void FakeBossOut()
    {
        m_FakeBoss.GetComponent<Animator>().SetTrigger("FakeBossOut");
        m_FakeBoss.GetComponent<AudioSource>().mute = true;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
