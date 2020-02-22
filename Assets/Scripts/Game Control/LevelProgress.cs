﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    [Tooltip("level time in SECONDS")]
    [SerializeField] float levelTime = 60f;
    [SerializeField] Slider progress;

    void Update()
    {
        progress.value = Time.timeSinceLevelLoad / levelTime;

        if (Time.timeSinceLevelLoad >= levelTime)
        {
            Debug.Log("Level time reached.");
        }
    }
}
