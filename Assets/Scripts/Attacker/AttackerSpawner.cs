using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    // config
    [SerializeField] Attacker attackerPrefab;
    [SerializeField] float initializationTime = 6f;
    [SerializeField] float maxSpawnGap = 20f;
    [SerializeField] float minSpawnGap = 5f;

    // state var
    [SerializeField] bool m_spawning = true;
    LevelController m_levelController;

    // for view
    [SerializeField] float spawnGap;

    void Start()
    {
        m_levelController = FindObjectOfType<LevelController>();

        StartCoroutine(WaitBeforeSpawn(initializationTime));
    }

    IEnumerator WaitBeforeSpawn(float initializationTime)
    {
        yield return new WaitForSeconds(initializationTime);
        SpawnAttacker();

        while (m_spawning)
        {
            spawnGap = UnityEngine.Random.Range(minSpawnGap, maxSpawnGap);
            yield return new WaitForSeconds(spawnGap);
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        var newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }

    public void SetSpawning(bool spawning)
    {
        m_spawning = spawning;
    }
}
