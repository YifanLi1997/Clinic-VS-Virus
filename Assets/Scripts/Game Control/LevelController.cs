using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject trueWinnerPanel;
    [SerializeField] GameObject winWithoutFreedonPanel;

    [SerializeField] Boss realBoss;
    [SerializeField] LevelProgress levelProgress;

    [SerializeField] int numberOfAttackers = 0;

    private void Update()
    {
        numberOfAttackers = FindObjectsOfType<Attacker>().Length;

        if (levelProgress.GetIsLevelProgressCompleted() && numberOfAttackers == 0)
        {
            if (realBoss.GetIsActive())
            {
                if (realBoss.GetIsDead())
                {
                    StartCoroutine(WaitAndEnd(trueWinnerPanel, 2f));
                }
            }
            else
            {
                StartCoroutine(WaitAndEnd(winWithoutFreedonPanel, 1f));
            }
        }
    }

    IEnumerator WaitAndEnd(GameObject panel, float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        panel.SetActive(true);
        Time.timeScale = 0;
    }


}
