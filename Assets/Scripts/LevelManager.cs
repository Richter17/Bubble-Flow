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
        activePanel = GetPanel("Game Over");
        if (activePanel)
        {
            activePanel.SetActive(true);
            //Color color;
            //ColorUtility.TryParseHtmlString("FFABAB64", out color);
            activePanel.GetComponent<Image>().color = new Color32(0xFF, 0xAB, 0xAB, 0x64);
            activePanel.GetComponentInChildren<Text>().text = "Pop!";
        }
        StartCoroutine(SetLevel(Application.loadedLevel, 1, false));
        
    }
    public void Win()
    {
        activePanel = GetPanel("Game Over");
        if (GetPanel("Game Over"))
        {
            activePanel.SetActive(true);
            //Color color;
            //ColorUtility.TryParseHtmlString("ABFFAF64", out color);
            activePanel.GetComponent<Image>().color = new Color32(0xAB, 0xFF, 0xAF, 0x64);
            activePanel.GetComponentInChildren<Text>().text = "You Win!";
        }
        #if UNITY_EDITOR
        StartCoroutine(SetLevel(Application.loadedLevel, 1, true));
        #endif
    }

    private GameObject GetPanel(string panelName)
    {
        GameObject panel;
        panelManager.panels.TryGetValue(panelName, out panel);
        return panel;
    }

    IEnumerator SetLevel(int level, float delayInSeconds , bool restartLevel)
    {
        yield return new WaitForSeconds(delayInSeconds);
        activePanel.SetActive(false);
        if(restartLevel) Application.LoadLevel(level);
    }

}
