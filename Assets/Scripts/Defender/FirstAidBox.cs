using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidBox : Defender
{
    [SerializeField] MedicalPoints medicalPointsPrefab;

    MedicalPoints newMedicalPoints;
    Vector3 spawningPos;

    public void SpawnMedicalPoint()
    {
        spawningPos = new Vector3(transform.position.x + 0.36f, transform.position.y + 0.4f, -1f);
        newMedicalPoints = Instantiate(medicalPointsPrefab, spawningPos, transform.rotation);
        Destroy(newMedicalPoints.gameObject, 6f);
    }

}
