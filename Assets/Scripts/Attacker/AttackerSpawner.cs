using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    // config
    [SerializeField] Attacker attackerPrefab;
    [SerializeField] float maxSpawnGap = 5f;
    [SerializeField] float minSpawnGap = 1f;

    // state var
    bool spawning = true;

    // for view
    [SerializeField] float spawnGap;

    IEnumerator Start()
    {
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

    void Update()
    {
    }
}
