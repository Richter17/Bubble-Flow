using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleActivator : MonoBehaviour {

    Rigidbody rigid;
    SpriteRenderer image;
    Animator bubbleAnimator;
    int POP = Animator.StringToHash("pop");

    float bubbleFirstDrag;
    bool hitOnce;

    private void Start()
    {
        BubbleBehavior.hitSomething += Lose;
        bubbleAnimator = GetComponentInParent<Animator>();
        image = GetComponent<SpriteRenderer>();
        rigid = GetComponentInParent<Rigidbody>();
        bubbleFirstDrag = rigid.drag;
        //Debug.Log("ssds");
    }
    // Use this for initialization
    private void OnMouseDown()
    {
        HitBubble();
    }

    void Lose(bool lost)
    {
        if(!lost)
        {
            hitOnce = false;
            rigid.drag = bubbleFirstDrag;
            bubbleAnimator.SetTrigger(POP);
            //image.enabled = true;

        }
    }

    public void HitBubble()
    {
        
        if (hitOnce) return;
        bubbleAnimator.SetTrigger(POP);
        //image.enabled = false;
        rigid.velocity = new Vector3(0, -15, 0);
        rigid.drag = 0;
        hitOnce = true;
    }
}
