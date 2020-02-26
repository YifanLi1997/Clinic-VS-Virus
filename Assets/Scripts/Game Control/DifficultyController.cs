using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DifficultyController : MonoBehaviour
{
    [SerializeField] GameObject FOSButton;

    float m_difficultyLevel;
    TextMeshProUGUI m_FOSTextMesh;

    void Start()
    {
        m_difficultyLevel = PlayerPrefsController.GetDifficulty();
        m_FOSTextMesh = FOSButton.GetComponentInChildren<TextMeshProUGUI>();

        if (m_difficultyLevel == 0)
        {
            m_FOSTextMesh.text = 2500.ToString();
        }
        else if (m_difficultyLevel == 1)
        {
            m_FOSTextMesh.text = 5000.ToString();
        }
        else if (m_difficultyLevel == 2)
        {
            m_FOSTextMesh.text = 7500.ToString();
        }
    }
}
