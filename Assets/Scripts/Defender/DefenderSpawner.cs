using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] AudioClip spawnFailed;

    Defender defenderSelected;

    Cashier m_cashier;

    private void Start()
    {
        m_cashier = FindObjectOfType<Cashier>();
    }


    private void OnMouseDown()
    {
        SpawnDefener(defenderSelected);
    }

    public void SetDefenderSelected(Defender defender)
    {
        defenderSelected = defender;
    }
    

    private void SpawnDefener(Defender defenderSelected)
    {
        var cost = defenderSelected.GetCost();
        if (m_cashier.EnoughPointsOrNot(cost))
        {
            m_cashier.SpendPoints(cost);
            var mousePos = GetClickedSquare();
            Instantiate(defenderSelected, mousePos, Quaternion.identity);
        }
        else
        {
            AudioSource.PlayClipAtPoint(spawnFailed, transform.position);
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
