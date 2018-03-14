using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FansController : MonoBehaviour
{

    public float fanForce;
    public bool activateFan;
    public Rigidbody bubbleRigid;
    protected BlowEffectArea effectCollider;
    protected FanControllerInEditor fanControllerInEditor;

    protected bool windIsActivate;
    public virtual void Start()
    {
        effectCollider = GetComponentInChildren<BlowEffectArea>();
        fanControllerInEditor = GetComponent<FanControllerInEditor>();
    }

    public virtual void FixedUpdate()
    {
        Debug.Log("Called FixedUpdate in FansController");
    }

    public virtual void PushTheBubbleDepandsOnDistance(Rigidbody bubble)
    {
        //the distance from the bubble
        float x = (bubble.transform.position - transform.position).magnitude;
        //the multipilyer(a*x^2)
        float m = -10 / (fanControllerInEditor.windYArea*fanControllerInEditor.windYArea);
        //the equation of the Parabula f(x)=a*x^2+c
        float bubbleDistanceFromFan = m*x+1;
        Debug.Log(bubbleDistanceFromFan);
        bubble.AddForce((bubble.transform.position - transform.position).normalized * (fanForce * bubbleDistanceFromFan));
<<<<<<< HEAD:Assets/Scripts/FansController.cs
=======
    }

    public virtual void PushTheBubble(Rigidbody bubble)
    {
        bubble.AddForce((bubble.transform.position - transform.position).normalized * fanForce);
    }

    public virtual void ActivateWindFeedback()
    {
        windIsActivate = true;
        effectCollider.GetComponent<MeshRenderer>().material.color = new Color32(0, 234, 244, 25);
    }

    public virtual void DeactivateWindFeedback()
    {
        windIsActivate = false;
        effectCollider.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 0);
>>>>>>> bd8675cd1dd3947f5c5b39097a4a073a93049bd6:Assets/Scripts/Fans_Scripts/FansController.cs
    }
}

