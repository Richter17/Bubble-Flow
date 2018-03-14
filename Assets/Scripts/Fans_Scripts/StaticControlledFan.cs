using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticControlledFan : FansController {

    public override void FixedUpdate()
    {
        //base.FixedUpdate();
        if (activateFan)
        {
            ActivateWindFeedback();
            if (bubbleRigid)
            {
                PushTheBubble(bubbleRigid);
            }
        }
        else
        {
            DeactivateWindFeedback();
        }
        //Debug.Log(bubbleRigid);
    }
}
