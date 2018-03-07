using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderObject : MonoBehaviour {

    public bool canBeAttached;
    public bool canBeObtained;
    public bool isBouncy;
    public int pointWorth;

    public virtual void OnCollisionEnter(Collision coll)
    {
        if(canBeAttached)
        {
            Debug.Log("attached");
        }
        Debug.Log("hit something that is not wall or goal");
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("touch something that is not wall or goal");
    }

}
