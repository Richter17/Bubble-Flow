using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public string nextLevel;
    bool paused = false;

    private void Start()
    {
        BubbleBehavior.hitSomething += Win;
    }
    //public void Lose()
    //{
    //    GetPanel("Game Over");

    //    StartCoroutine(SetLevel(Application.loadedLevelName, 1, false));

    //}
    public void Win(bool win)
    {
        
        if (win)
        {
            
#if UNITY_EDITOR

            StartCoroutine(SetLevel(string.Empty, 1, true));
            return;
#endif
            StartCoroutine(SetLevel(nextLevel, 1, false));

        }

        
    }

    //private void GetPanel(string panelName)
    //{
    //    if (!panelManager.panels.TryGetValue(panelName, out activePanel)) return;
    //    activePanel.SetActive(true);

    //}

    IEnumerator SetLevel(string level, float delayInSeconds, bool restartLevel)
    {
        yield return new WaitForSeconds(delayInSeconds);
        if (restartLevel)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadSceneAsync(level);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        paused = (paused) ? false : true;
        Time.timeScale = (paused) ? 0 : 1;

    }

    public void ReturnToManu()
    {
        Debug.Log("Manu Requested");
        SceneManager.LoadSceneAsync("First Scene");
    }

    public void Quit()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }


}
