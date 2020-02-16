using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidBox : Defender
{
    [SerializeField] MedicalPoints medicalPointsPrefab;

    float spawningCount = 3f;
    MedicalPoints newMedicalPoints;
    Vector3 spawningPos;

    private void Start()
    {
    }

    public void Update()
    {
        if (spawningCount >= 12f)
        {
            spawningCount -= Time.deltaTime;
            spawningPos = new Vector3(transform.position.x + 0.36f, transform.position.y + 0.4f, -1f);
            newMedicalPoints = Instantiate(medicalPointsPrefab, spawningPos, transform.rotation);
            Destroy(newMedicalPoints.gameObject, 6f);
        }
        else if (spawningCount <= 0)
        {
            spawningCount = 12f;
        }
        else
        {
            spawningCount -= Time.deltaTime;
        }
    }
}
