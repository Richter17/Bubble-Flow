using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticControlledFan : FansController {

    public override void FixedUpdate()
    {
        //base.FixedUpdate();
        if (activateFan)
        {
            if (wind.isStopped)
                wind.Play();
            if (bubbleRigid)
            {
                Debug.Log("push bubble to" + (transform.GetChild(0).position - transform.position));
                bubbleRigid.AddForce((transform.GetChild(0).position - transform.position).normalized * fanForce);
            }
        }
        else
        {
            if (wind.isPlaying)
                wind.Stop();

        }
        //Debug.Log(bubbleRigid);
    }
}
