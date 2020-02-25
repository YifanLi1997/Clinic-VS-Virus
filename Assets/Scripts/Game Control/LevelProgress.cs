using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [Tooltip("level time in SECONDS")]
    [SerializeField] float levelTime = 10f;

    [SerializeField] Animator progressHandle;

    AttackerSpawner[] m_attackerSpawners;
    [SerializeField] bool isLevelProgressCompleted = false;

    private void Start()
    {
        m_attackerSpawners = FindObjectsOfType<AttackerSpawner>();
    }

    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        if (Time.timeSinceLevelLoad >= levelTime)
        {
            isLevelProgressCompleted = true;
            progressHandle.SetTrigger("isEnded");

            foreach (var spawner in m_attackerSpawners)
            {
                spawner.SetSpawning(false);
            }
        }
    }

    public bool GetIsLevelProgressCompleted()
    {
        return isLevelProgressCompleted;
    }
}
