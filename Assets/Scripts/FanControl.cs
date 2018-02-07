using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanControl : MonoBehaviour {

    public float fanForce;
    public bool activateFan;
    Rigidbody bubbleRigid;
    ParticleSystem wind;
    Camera cam;
    
	// Use this for initialization
	void Start () {
        wind = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

		if(activateFan)
        {
            if (wind.isStopped)
                wind.Play();
            if(bubbleRigid)
            {
                //Debug.Log("push bubble");
                bubbleRigid.AddForce((bubbleRigid.transform.position - transform.position).normalized * fanForce*Time.deltaTime);
            }
        }
        else
        {
            if(wind.isPlaying)
                wind.Stop();
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            bubbleRigid = other.gameObject.GetComponent<Rigidbody>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Rigidbody>())
        {
            bubbleRigid = null;
        }
    }
}
