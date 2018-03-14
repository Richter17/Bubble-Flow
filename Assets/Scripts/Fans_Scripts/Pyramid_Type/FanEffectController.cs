using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FanEffectController : MonoBehaviour {

    public float windHeight;
    public float windWidth;
    private Transform windCollider;
    // Use this for initialization
    void Start () {
        //first get the default size of the fan
        windCollider = GetComponentInChildren<BlowEffectArea>().transform;
        windHeight = windCollider.localPosition.y + windCollider.localScale.z;
        windWidth = windCollider.localPosition.x + windCollider.localScale.x;
        //get the particle system from the fan parent
    }

    // Update is called once per frame
    void Update () {
        Vector3 colliderPos = new Vector3(0, windHeight / 5.2f, 0);
        Vector3 colliderScale = new Vector3(windWidth, windCollider.localScale.y , windHeight / 1.25f);

        windCollider.localScale = colliderScale;
        windCollider.localPosition = colliderPos;
    }
}
