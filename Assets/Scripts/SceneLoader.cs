using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 3;

    int currentSceneIndex;
    
    void Start()
	{
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if (currentSceneIndex == 0)
		{
            StartCoroutine(WaitAndLoad(timeToWait));
		}
    }

    IEnumerator WaitAndLoad(int time)
	{
        yield return new WaitForSeconds(time);
        LoadNextScene();
    }

    public void LoadNextScene()
	{
        SceneManager.LoadScene(currentSceneIndex + 1);
	}

    public void OnApplicationQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
