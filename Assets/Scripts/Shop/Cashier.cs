using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cashier : MonoBehaviour
{

    // For view purpose
    [SerializeField] int points = 100;

    TextMeshProUGUI m_pointsText;

    // Start is called before the first frame update
    void Start()
    {
        m_pointsText = GetComponent<TextMeshProUGUI>();
        m_pointsText.text = points.ToString();
    }

    public void AddPoints(int addedPoints)
    {
        points += addedPoints;
        m_pointsText.text = points.ToString();
    }

    public bool EnoughPointsOrNot(int spendedPoints)
    {
        if (points >= spendedPoints)
        {
            return true;
        }
        return false;
    }

    public void SpendPoints(int spendedPoints)
    {
        points -= spendedPoints;
        m_pointsText.text = points.ToString();
    }
}
