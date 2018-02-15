using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour {
    public string nextScene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BubbleBehavior>())
        {
            other.gameObject.layer = LayerMask.NameToLayer("Win");
            Debug.Log("You Win");
            LevelManager.manager.Win(nextScene);
        }
    }

}
