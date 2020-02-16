using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicalPoints : MonoBehaviour
{
    [SerializeField] GameObject explosionVFXPrefab;

    int medicalPoints = 50;

    Cashier m_cashier;

    private void Start()
    {
        m_cashier = FindObjectOfType<Cashier>();
    }

    private void OnMouseDown()
    {
        m_cashier.AddPoints(medicalPoints);
        Destroy(gameObject);
        var explosionVFX = Instantiate(explosionVFXPrefab, transform.position, transform.rotation);
        Destroy(explosionVFX, 1f);
    }
}
