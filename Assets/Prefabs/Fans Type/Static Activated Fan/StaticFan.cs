using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFan : FansController {

    public override void Start()
    {
        base.Start();
        wind.Play();
    }
    public override void FixedUpdate()
    {
        //base.FixedUpdate();
        if (bubbleRigid)
        {
            //Debug.Log("push bubble to" + (transform.GetChild(0).position - transform.position));
            bubbleRigid.AddForce((transform.GetChild(0).position - transform.position).normalized * fanForce);
        }
    }
}
