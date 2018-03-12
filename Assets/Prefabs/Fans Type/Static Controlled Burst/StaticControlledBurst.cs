using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticControlledBurst : FansController {
    public float burstTime = 0.3f;

    float curTime;
    bool burst;
    bool letGo = true;
    private void Update()
    {
        if(Time.time-curTime>burstTime)
        {
            burst = false;
            
            if (wind.isPlaying)
            {
                wind.Stop();
                letGo = false;
            }
                
        }

        if(!Input.GetMouseButton(0))
        {
            letGo = true;
        }
        //Debug.Log("Burst is" + burst);
        //Debug.Log("letGo is" + letGo);
    }
    public override void FixedUpdate()
    {
        if(activateFan)
        {
            
            if (burst)
            {
                if (letGo)
                {
                    if (wind.isStopped)
                        wind.Play();

                    if (bubbleRigid)
                    {
                        PushTheBubble(bubbleRigid);
                    }
                }
            }
            else
            {
                burst = true;
                curTime = Time.time;
            }           
            
        }
        //base.FixedUpdate();
        
    }

    //Create A function that divide the angle to three
}
