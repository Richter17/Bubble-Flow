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
                PushTheBubble(bubbleRigid);
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
