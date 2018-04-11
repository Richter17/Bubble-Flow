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
    protected ParticleSystem windParticleEffect;
    protected Animator fanAnimatorController;

    int START_ANIM = Animator.StringToHash("activated");

    protected bool windIsActivate;
    bool playOnce;
    public virtual void Start()
    {
        effectCollider = GetComponentInChildren<BlowEffectArea>();
        fanControllerInEditor = GetComponent<FanControllerInEditor>();
        windParticleEffect = GetComponentInChildren<ParticleSystem>();
        fanAnimatorController = GetComponent<Animator>();
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
    }

    public virtual void PushTheBubble(Rigidbody bubble)
    {
        bubble.AddForce((bubble.transform.position - transform.position).normalized * fanForce);
    }

    public virtual void ActivateWindFeedback()
    {
        windIsActivate = true;
        if (!playOnce)
        {
            windParticleEffect.Play();
            playOnce = true;
        }
            
        fanAnimatorController.SetBool(START_ANIM, true);
        //effectCollider.GetComponent<MeshRenderer>().material.color = new Color32(0, 234, 244, 25);
    }

    public virtual void DeactivateWindFeedback()
    {
        windIsActivate = false;
        if (windParticleEffect.isPlaying) windParticleEffect.Stop();
        playOnce = false;
        fanAnimatorController.SetBool(START_ANIM, false);
        //effectCollider.GetComponent<MeshRenderer>().material.color = new Color32(255, 255, 255, 0);
    }
}

