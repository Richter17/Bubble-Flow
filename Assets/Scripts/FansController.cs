using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FansController : MonoBehaviour
{

    public float fanForce;
    public bool activateFan;
    public Rigidbody bubbleRigid;
    protected ParticleSystem wind;

    public virtual void Start()
    {
        wind = GetComponentInChildren<ParticleSystem>();
    }

    public virtual void FixedUpdate()
    {
        Debug.Log("Called FixedUpdate in FansController");
    }
}

