using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager manager;
    public PanelManager panelManager;
    GameObject activePanel;
    private void Awake()
    {
        if (manager != null)
        {
            Debug.LogError("Singleton violation");
            return;
        }
        manager = this;
    }
    public void Lose()
    {
        GetPanel("Game Over");

        StartCoroutine(SetLevel(Application.loadedLevelName, 1, false));
        
    }
    public void Win(string sceneName)
    {
        GetPanel("Win");
        StartCoroutine(SetLevel(sceneName, 1, true));
        //#if UNITY_EDITOR
        //StartCoroutine(SetLevel(Application.loadedLevel, 1, true));
        //#endif
    }

    private void GetPanel(string panelName)
    {
        if (!panelManager.panels.TryGetValue(panelName, out activePanel)) return;
        activePanel.SetActive(true);

    }

    IEnumerator SetLevel(string level, float delayInSeconds , bool restartLevel)
    {
        yield return new WaitForSeconds(delayInSeconds);
        if(activePanel!=null) activePanel.SetActive(false);
        if(restartLevel) SceneManager.LoadScene(level);
    }

    public void Quit()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

    public void EnterAScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
