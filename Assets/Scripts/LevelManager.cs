using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float twoStars = 40, oneStar = 80, allStars = 100;

    static public int objectiveBubbles = 0;
    int maxBubbles = 0;
    float levelGrade = 0;

    bool paused = false;

    private void Start()
    {
        BubbleBehavior.hitSomething += Win;
        maxBubbles = objectiveBubbles;
        Debug.Log("max bubbles" + maxBubbles);
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

            levelGrade = (float)objectiveBubbles / (float)maxBubbles;
            levelGrade *= 100;

            if (100>levelGrade&& levelGrade > oneStar)
            {
                Debug.Log("One Star");
            }
            else if (oneStar > levelGrade && levelGrade > twoStars)
            {
                Debug.Log("Two Stars");
            }
            else if (twoStars > levelGrade && levelGrade > 0)
            {
                Debug.Log("Three Stars");
            }
            else if( levelGrade <= 0)
            {
                Debug.Log("All Stars Collected");
            }
            //#if UNITY_EDITOR

            //            StartCoroutine(SetLevel(string.Empty, 1, true));
            //            return;
            //#endif    
            
            //StartCoroutine(SetLevel(nextLevel, 1, false));

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
        Time.timeScale = 1;
        objectiveBubbles = 0;
        CheckIfPaused();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        paused = (paused) ? false : true;
        Time.timeScale = (paused) ? 0 : 1;

    }

    public void ReturnToManu()
    {
        CheckIfPaused();
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

    public void LoadNextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetObjectiveBubbles()
    {
        objectiveBubbles = 0;
    }

    private void CheckIfPaused()
    {
        if(paused)
        {
            Time.timeScale = 1;
        }
    }

}
