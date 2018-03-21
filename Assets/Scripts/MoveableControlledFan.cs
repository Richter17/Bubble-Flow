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

    bool isPressed;
    Vector3 touchPosition;
    Vector3 firstPos;
    Vector3 newPosition;
    float veriable;
    public override void Start()
    {
        base.Start();
        firstPos = newPosition = transform.position;
    }

    private void Update()
    {
        if (isPressed)
        {
            touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //veriable = Input.mousePosition.x - firstPosTouch.x;
            if (axis == Axis.X)
            {
                
                veriable = Mathf.Clamp(touchPosition.x, firstPos.x - (distance / 2), firstPos.x + (distance / 2));
                newPosition.x = veriable;
            }
            else if (axis == Axis.Y)
            {
                veriable = Mathf.Clamp(touchPosition.y, firstPos.y - (distance / 2), firstPos.y + (distance / 2));
                newPosition.y = veriable;
            }
            //firstPos.x = veriable;
            transform.position = newPosition;
        }
    }

    public override void FixedUpdate()
    {
        //base.FixedUpdate();
        if (activateFan)
        {
            if(!isPressed)
                touchPosition = Input.mousePosition;

            isPressed = true;

            ActivateWindFeedback();

            if (bubbleRigid)
            {
                PushTheBubble(bubbleRigid);
            }
        }
        else
        {
            isPressed = false;
            DeactivateWindFeedback();
        }
    }
}
