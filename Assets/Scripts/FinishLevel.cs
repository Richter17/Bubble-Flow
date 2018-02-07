using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour {

    public LevelManager levelManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BubbleBehavior>())
        {
            Debug.Log("You Win");
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2);

        //if there are next levels
        //levelManager.LoadNextLevel();
        //for now return to the same level
        levelManager.RestartLevel();
    }
}
