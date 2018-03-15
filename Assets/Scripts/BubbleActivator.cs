using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleActivator : MonoBehaviour {

    Rigidbody rigid;
    SpriteRenderer image;

    float bubbleFirstDrag;

    private void Start()
    {
        BubbleBehavior.hitSomething += Lose;
        image = GetComponent<SpriteRenderer>();
        rigid = GetComponentInParent<Rigidbody>();
        bubbleFirstDrag = rigid.drag;
    }
    // Use this for initialization
    private void OnMouseDown()
    {
        image.enabled = false;
        rigid.velocity = new Vector3(0, -15, 0);
        rigid.drag = 0;
    }

    void Lose(bool lost)
    {
        if(!lost)
        {
            rigid.drag = bubbleFirstDrag;
            image.enabled = true;
        }
    }
}
