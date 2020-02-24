using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [Header("[Optional] Loading Screen")]
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI porgressText;

    public void LoadStartScreen()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }

    public void LoadNextScene()
	{
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

    public void LoadNextSceneWithALoadingBar()
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously());
    }

    IEnumerator LoadAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .91f);
            slider.value = progress;
            porgressText.text = Mathf.RoundToInt(progress*100).ToString() + "%";

            yield return null;
        }
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
