using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBubble : ColliderObject {

    public override void OnTriggerEnter(Collider other)
    {
        //base.OnTriggerEnter(other);
        if(canBeObtained)
        {
            Debug.Log("Collect Bubble!");
            Destroy(gameObject);
        }
    }
}
