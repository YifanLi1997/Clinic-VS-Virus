using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    [SerializeField] int cost;

    DefenderSpawner m_defenderSpawner;
    DefenderButton[] m_defenderButtons;


    private void Start()
    {
        m_defenderSpawner = FindObjectOfType<DefenderSpawner>();
        m_defenderButtons = FindObjectsOfType<DefenderButton>();
    }

    private void OnMouseDown()
    {
        foreach (var button in m_defenderButtons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(120, 120, 120, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        m_defenderSpawner.SetDefenderSelected(defenderPrefab);
    }
}
