using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveCounter : MonoBehaviour {


    Text score;

    int maxObjectiveBubbles;

    private void Start()
    {
        score = GetComponent<Text>();
        maxObjectiveBubbles = LevelManager.objectiveBubbles;
    }
    void Update () {
        score.text = (maxObjectiveBubbles-LevelManager.objectiveBubbles).ToString() + "/" + maxObjectiveBubbles.ToString();
	}
}
