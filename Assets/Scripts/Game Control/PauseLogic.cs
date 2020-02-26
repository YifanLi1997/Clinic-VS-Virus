using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    public static bool gameIsPaused;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject clickBlocker;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        clickBlocker.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        clickBlocker.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
}
