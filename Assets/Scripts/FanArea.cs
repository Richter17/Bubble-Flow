using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanArea : MonoBehaviour {

    private FanControl fanControl;

    private void Start()
    {
        fanControl = transform.parent.GetComponent<FanControl>();
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
