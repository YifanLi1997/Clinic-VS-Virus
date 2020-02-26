using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidBox : Defender
{
    [SerializeField] MedicalPoints medicalPointsPrefab;

    public void SpawnMedicalPoint()
    {
        var spawningPos = new Vector3(transform.position.x + 0.36f, transform.position.y + 0.4f, -1f);
        var newMedicalPoints = Instantiate(medicalPointsPrefab, spawningPos, transform.rotation);
        Destroy(newMedicalPoints.gameObject, 6f);
    }

}
