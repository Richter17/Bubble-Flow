using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearObjectAfterLose : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BubbleBehavior.hitSomething += Disapear;
	}

    void Disapear(bool win)
    {
       gameObject.SetActive(false);     
    }
	
	
}
