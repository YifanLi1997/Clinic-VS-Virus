using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalMPSpawner : MonoBehaviour
{
    [SerializeField] MedicalPoints medicalPointsPrefab;
    MedicalPoints newMedicalPoints;

    // spawning time
    float minGapTime = 12f;
    float maxGapTime = 24f;
    float spawningCount = 6f;

    // spawning position
    float minXOffest = -4.5f;
    float maxXOffest = 4.5f;
    float minYOffest = -1.5f;
    float maxYOffest = -6.5f;
    float xOffset;
    float yOffset;
    float speed = 0.5f;
    Vector3 endingPos;
    Vector3 spawningPos;

    private void Start()
    {
    }

    public void Update()
    {
        if (spawningCount >= 24f)
        {
            spawningCount -= Time.deltaTime;

            xOffset = Random.Range(minXOffest, maxXOffest);
            yOffset = Random.Range(minYOffest, maxYOffest);
            endingPos = new Vector3(transform.position.x + xOffset, transform.position.y + yOffset, -5f);
            spawningPos = new Vector3(endingPos.x, transform.position.y, -5f);

            newMedicalPoints = Instantiate(medicalPointsPrefab, spawningPos, transform.rotation);
            newMedicalPoints.transform.parent = transform;
            Destroy(newMedicalPoints.gameObject, 18f);
        }
        else if (spawningCount <= 0)
        {
            //spawningCount = Random.Range(minGapTime, maxGapTime);
            spawningCount = 24f;
        }
        else
        {
            spawningCount -= Time.deltaTime;
        }

        if (newMedicalPoints)
        {
            newMedicalPoints.transform.position = Vector3.MoveTowards(
                newMedicalPoints.transform.position,
                endingPos,
                speed * Time.deltaTime);
        }
    }

}
