using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyController : MonoBehaviour
{
    float m_difficultyLevel;
    GameObject m_FOSButton;

    void Start()
    {
        m_difficultyLevel = PlayerPrefsController.GetDifficulty();

        m_FOSButton = GameObject.Find("FOS Button");

        if (m_difficultyLevel == 0)
        {
            m_FOSButton.GetComponent<DefenderButton>().SetCost(2500);
        }
        else if (m_difficultyLevel == 1)
        {
            m_FOSButton.GetComponent<DefenderButton>().SetCost(5000);
        }
        else if (m_difficultyLevel == 2)
        {
            m_FOSButton.GetComponent<DefenderButton>().SetCost(7500);
        }
    }
}
