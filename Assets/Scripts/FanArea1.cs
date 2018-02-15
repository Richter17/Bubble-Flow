using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanArea1 : MonoBehaviour {

	private StaticFan fanControl;


    private void Start()
    {
        fanControl = transform.parent.GetComponent<StaticFan>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            fanControl.bubbleRigid = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            fanControl.bubbleRigid = null;
        }
    }
}
