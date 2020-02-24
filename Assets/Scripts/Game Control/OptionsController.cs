using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;

    AudioSource m_audioSource;

    private void Start()
    {
        m_audioSource = FindObjectOfType<AudioSource>();

        volumeSlider.value = PlayerPrefsController.GetVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void Update()
    {
        PlayerPrefsController.SetVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        m_audioSource.volume = PlayerPrefsController.GetVolume();
    }

    public void SetDefaultValues()
    {
        volumeSlider.value = 0.5f;
        difficultySlider.value = 1;
    }
}
