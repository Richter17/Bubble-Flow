using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

        StartCoroutine(SetLevel(Application.loadedLevel, 1, false));
        
    }
    public void Win()
    {
        GetPanel("Win");
        
        #if UNITY_EDITOR
        StartCoroutine(SetLevel(Application.loadedLevel, 1, true));
        #endif
    }

    private void GetPanel(string panelName)
    {
        if (!panelManager.panels.TryGetValue(panelName, out activePanel)) return;
        activePanel.SetActive(true);

    }

    IEnumerator SetLevel(int level, float delayInSeconds , bool restartLevel)
    {
        yield return new WaitForSeconds(delayInSeconds);
        if(activePanel!=null) activePanel.SetActive(false);
        if(restartLevel) Application.LoadLevel(level);
    }

}
