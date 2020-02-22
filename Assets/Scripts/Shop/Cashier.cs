using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cashier : MonoBehaviour
{

    // For view purpose
    [SerializeField] int points = 50;

    [SerializeField] TextMeshProUGUI pointsTMP;

    // Start is called before the first frame update
    void Start()
    {
        pointsTMP.text = points.ToString();
    }

    public void AddPoints(int addedPoints)
    {
        points += addedPoints;
        pointsTMP.text = points.ToString();
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
        pointsTMP.text = points.ToString();
    }
}
