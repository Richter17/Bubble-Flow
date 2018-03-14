using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FanControllerInEditor : MonoBehaviour {


    //This Script allow you to edit the wind area of the fan
    //set the y and x of the the collider area
    public float windYArea;
    public float windXArea;
    private Transform windCollider;
    
    // Use this for initialization
    void Start () {
        //first get the default size of the fan
        windCollider = GetComponentInChildren<BlowEffectArea>().transform;
        windYArea = windCollider.localPosition.y + windCollider.localScale.y;
        windXArea = windCollider.localPosition.x + windCollider.localScale.x;
        //get the particle system from the fan parent
        


        //set the 

    }
	
	// Update is called once per frame
	void Update () {
        //with two vector3 sets the local scale and the position of the collider in accordance to the fan itself
        Vector3 colliderPos = new Vector3(0, windYArea / 2, 0);
        Vector3 colliderScale = new Vector3(windXArea, windYArea / 2, 0);

        windCollider.localScale = colliderScale;
        windCollider.localPosition = colliderPos;

        //ParticleSystem windShow = GetComponentInChildren<ParticleSystem>();
        //var main = windShow.main;
        //var shape = windShow.shape;
        //var emisson = windShow.emission;
        //emisson.rateOverTime = windXArea * 200 / 3;
        //shape.radius = 0.37f*windXArea -0.25f;
        //main.startSpeed = windYArea;
        
    }
}
