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
            PushTheBubble(bubbleRigid);
        }
    }
}
