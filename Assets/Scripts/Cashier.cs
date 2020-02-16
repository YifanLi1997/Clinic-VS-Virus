using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cashier : MonoBehaviour
{

    // For view purpose
    [SerializeField] int points = 100;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = points.ToString();
    }

    public void AddPoints(int addedPoints)
    {
        points += addedPoints;
        GetComponent<TextMeshProUGUI>().text = points.ToString();
    }

    public bool SpendPoints(int spendedPoints)
    {
        if (points >= spendedPoints)
        {
            points -= spendedPoints;
            GetComponent<TextMeshProUGUI>().text = points.ToString();
            return true;
        }
        return false;
    }

}
