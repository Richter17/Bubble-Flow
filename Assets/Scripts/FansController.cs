using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FansController : MonoBehaviour
{

    public float fanForce;
    public bool activateFan;
    public Rigidbody bubbleRigid;
    protected ParticleSystem wind;
    protected FanControllerInEditor fanControllerInEditor;

    public virtual void Start()
    {
        wind = GetComponentInChildren<ParticleSystem>();
        fanControllerInEditor = GetComponent<FanControllerInEditor>();
    }

    public virtual void FixedUpdate()
    {
        Debug.Log("Called FixedUpdate in FansController");
    }

    public virtual void PushTheBubble(Rigidbody bubble)
    {
        //the distance from the bubble
        float x = (bubble.transform.position - transform.position).magnitude;
        //the multipilyer(a*x^2)
        float m = -10 / (fanControllerInEditor.windYArea*fanControllerInEditor.windYArea);
        //the equation of the Parabula f(x)=a*x^2+c
        float bubbleDistanceFromFan = m*x+1;
        Debug.Log(bubbleDistanceFromFan);
        //bubble.AddForce((bubble.transform.position - transform.position).normalized * (fanForce * bubbleDistanceFromFan));
    }
}

