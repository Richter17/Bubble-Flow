using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableControlledFan : FansController {
    
    public enum Axis
    {
        X,Y
    }

    public Axis axis;
    public float distance = 5;
    public float divider;

    bool isPressed;
    Vector3 firstPosTouch;
    Vector3 firstPos;
    float veriable;
    public override void Start()
    {
        base.Start();
        Vector3 firstPos = transform.position;
    }

    private void Update()
    {
        if (isPressed)
        {
            
            if (axis == Axis.X)
            {
                veriable = Mathf.Clamp((Input.mousePosition.x - firstPosTouch.x)/divider, transform.position.x - (distance / 2), transform.position.x + (distance / 2));
                firstPos.x = veriable;
            }
            else if(axis == Axis.Y)
            {
                veriable = Mathf.Clamp((Input.mousePosition.y - firstPosTouch.y) / divider, transform.position.y - (distance / 2), transform.position.y + (distance / 2));
                firstPos.y = veriable;
            }

            transform.position = firstPos;
        }
    }

    public override void FixedUpdate()
    {
        //base.FixedUpdate();
        if (activateFan)
        {
            isPressed = true;
            firstPosTouch = Input.mousePosition;
            if (wind.isStopped)
                wind.Play();
            if (bubbleRigid)
            {
                //Debug.Log("push bubble to" + (transform.GetChild(0).position - transform.position));
                bubbleRigid.AddForce((transform.GetChild(0).position - transform.position).normalized * fanForce);
            }
        }
        else
        {
            if (wind.isPlaying)
                wind.Stop();
            isPressed = false;
        }
    }
}
