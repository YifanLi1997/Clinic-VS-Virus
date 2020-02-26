using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] AudioClip spawnFailed;
    [SerializeField] Cashier cashier;
    [SerializeField] GameObject defenders;

    Defender m_defenderSelected;
    int m_cost;


    private void OnMouseDown()
    {
        if (m_defenderSelected)
        {
            SpawnDefener(m_defenderSelected);
        }
        else
        {
            return;
        }
        
    }

    public void SetDefenderSelected(Defender defender)
    {
        m_defenderSelected = defender;
    }
    

    private void SpawnDefener(Defender defenderSelected)
    {
        CalculateCost(defenderSelected);

        if (cashier.EnoughPointsOrNot(m_cost))
        {
            cashier.SpendPoints(m_cost);
            var mousePos = GetClickedSquare();
            var newDefender = Instantiate(defenderSelected, mousePos, Quaternion.identity);
            newDefender.gameObject.transform.parent = defenders.transform;

        }
        else
        {
            AudioSource.PlayClipAtPoint(
                spawnFailed,
                Camera.main.transform.position,
                PlayerPrefsController.GetVolume());
        }
    }

    private void CalculateCost(Defender defenderSelected)
    {
        if (defenderSelected.GetComponent<FreedomOfSpeech>())
        {
            if (PlayerPrefsController.GetDifficulty() == 0)
            {
                m_cost = 2500;
            }
            else if (PlayerPrefsController.GetDifficulty() == 1)
            {
                m_cost = 5000;
            }
            else
            {
                m_cost = 7500;
            }
        }
        else
        {
            m_cost = defenderSelected.GetCost();
        }
    }

    private Vector2 GetClickedSquare()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 roundedPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));
        return roundedPos;
    }

}
