using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activations : MonoBehaviour {

    public Camera cam;
    FanControl fanControl;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                fanControl = hit.transform.GetComponent<FanControl>();

                if (fanControl)
                {
                    fanControl.activateFan = true;
                    Debug.Log(fanControl.gameObject.name);
                }
                
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            fanControl.activateFan = false;
        }
        
    }
}
