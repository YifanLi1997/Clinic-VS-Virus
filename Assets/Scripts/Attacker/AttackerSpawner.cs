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
    bool spawning = true;

    // for view
    [SerializeField] float spawnGap;

    void Start()
    {
        StartCoroutine(WaitBeforeSpawn(initializationTime));
    }

    IEnumerator WaitBeforeSpawn(float initializationTime)
    {
        yield return new WaitForSeconds(initializationTime);
        SpawnAttacker();

        while (spawning)
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
}
