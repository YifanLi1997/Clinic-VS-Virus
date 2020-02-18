using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawnerInitializer : MonoBehaviour
{
    [SerializeField] AttackerSpawner[] attackerSpawners;

    private void Start()
    {
        StartCoroutine(InitializeSpawnersOneByOne(attackerSpawners));
    }

    IEnumerator InitializeSpawnersOneByOne(AttackerSpawner[] attackerSpawners)
    {
        List<int> warehouse = new List<int>();

        while (warehouse.Count < attackerSpawners.Length)
        {
            int index = Random.Range(0, attackerSpawners.Length);

            if (warehouse.Contains(index))
            {
                continue;
            }
            else
            {
                attackerSpawners[index].gameObject.SetActive(true);
                warehouse.Add(index);
            }

            yield return new WaitForSeconds(1f);
        }
    }

}
