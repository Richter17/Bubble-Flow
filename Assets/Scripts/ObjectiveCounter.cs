using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveCounter : MonoBehaviour {


    public Text score;
    Slider counter;

    int maxObjectiveBubbles;

    private void Start()
    {
        counter = GetComponent<Slider>();
        maxObjectiveBubbles = LevelManager.objectiveBubbles;
    }
    void Update () {
        score.text = (maxObjectiveBubbles-LevelManager.objectiveBubbles).ToString() + "/" + maxObjectiveBubbles.ToString();
        counter.value = (float)LevelManager.objectiveBubbles / (float)maxObjectiveBubbles * 100;
	}
}
