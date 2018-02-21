using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowEffectArea : MonoBehaviour {

    private FansController fansController;
    private void Start()
    {
        fansController = transform.parent.GetComponent<FansController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BubbleBehavior>())
        fansController.bubbleRigid = other.GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<BubbleBehavior>())
            fansController.bubbleRigid = null;
    }
}
