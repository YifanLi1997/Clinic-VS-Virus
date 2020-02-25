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
    TextMeshProUGUI m_text;


    private void Start()
    {
        m_defenderSpawner = FindObjectOfType<DefenderSpawner>();
        m_defenderButtons = FindObjectsOfType<DefenderButton>();
        m_text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        m_text.text = cost.ToString();
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

    public void SetCost(int mp)
    {
        cost = mp;
    }


}
