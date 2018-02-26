using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

    public GameObject winPanel, losePanel, pausePanel;
    bool paused = false;
    private void Start()
    {
        BubbleBehavior.hitSomething += OccurOnBubbleHit;
    }
    void OccurOnBubbleHit(bool isGoal)
    {
        if (isGoal)
        {
            //show win go to nex level
            Debug.Log("win panel");
            StartCoroutine(ShowPanelAndHideIt(winPanel));
        }
        else
        {
            //show lose panel return t0 start
            Debug.Log("you lose");
            StartCoroutine(ShowPanelAndHideIt(losePanel));
        }
    }

    public void ShowHidePausePanel()
    {
        paused = (paused) ? false : true;
        pausePanel.SetActive(paused);

    }

    IEnumerator ShowPanelAndHideIt(GameObject panel)
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(1);
        panel.SetActive(false);
    }

}
