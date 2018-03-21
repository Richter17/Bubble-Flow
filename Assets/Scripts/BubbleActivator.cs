using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleActivator : MonoBehaviour {

    Rigidbody rigid;
    SpriteRenderer image;

    float bubbleFirstDrag;
    bool hitOnce;

    private void Start()
    {
        BubbleBehavior.hitSomething += Lose;
        image = GetComponent<SpriteRenderer>();
        rigid = GetComponentInParent<Rigidbody>();
        bubbleFirstDrag = rigid.drag;
        Debug.Log("ssds");
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
            image.enabled = true;
        }
    }

    public void HitBubble()
    {
        Debug.Log("hit");
        if (hitOnce) return;
        image.enabled = false;
        rigid.velocity = new Vector3(0, -15, 0);
        rigid.drag = 0;
        hitOnce = true;
    }
}
