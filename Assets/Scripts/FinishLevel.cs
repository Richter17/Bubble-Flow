using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BubbleBehavior>())
        {
            Debug.Log("You Win");
            LevelManager.manager.Win();
        }
    }

}
