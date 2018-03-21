using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activations : MonoBehaviour {

    private Camera cam;
    FansController fansController;
    BubbleActivator bubbleActivator;
	// Use this for initialization
	void Start () {
        cam = GameObject.FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                fansController = hit.transform.GetComponent<FansController>();

                if (fansController)
                {
                    fansController.activateFan = true;
                    return;
                    //Debug.Log(fanControl.gameObject.name);
                }

                //bubbleActivator = hit.transform.GetComponent<BubbleActivator>();
                //if (bubbleActivator)
                //{
                //    bubbleActivator.HitBubble();
                //}
                
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if (fansController == null) return;
            fansController.activateFan = false;
        }
        
    }
}
