using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseTrigger : MonoBehaviour
{
    [SerializeField] Boss realBoss;
    [SerializeField] GameObject loserWithFreedomPanel;
    [SerializeField] GameObject loserPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (realBoss.GetIsActive())
        {
            loserWithFreedomPanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            loserPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
