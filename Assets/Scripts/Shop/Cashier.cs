using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Cashier : MonoBehaviour
{

    // For view purpose
    [SerializeField] int points = 50;
    [SerializeField] TextMeshProUGUI pointsTMP;


    void Start()
    {
        pointsTMP.text = points.ToString();
    }

    private void Update()
    {
        AddPointsInBackDoor();
    }

    private void AddPointsInBackDoor()
    {
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            AddPoints(1000);
        }
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
