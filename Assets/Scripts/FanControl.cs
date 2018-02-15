using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanControl : MonoBehaviour {
    //public Vector3 gismoPos, gismoWirePos;
    public float fanForce;
    public bool activateFan;
    public Rigidbody bubbleRigid;
    BoxCollider box;
    ParticleSystem wind;

    private void OnDrawGizmos()
    {
        box = GetComponentInChildren<FanArea>().GetComponent<BoxCollider>();
        Matrix4x4 effectArea = Matrix4x4.TRS(transform.position, transform.rotation, box.size);
        Gizmos.matrix = effectArea;

        Gizmos.DrawWireCube(new Vector3(0,(box.center.y/box.size.y)), transform.localScale);
    }

    // Use this for initialization
    void Start () {
        box = GetComponentInChildren<FanArea>().GetComponent<BoxCollider>();
        wind = GetComponentInChildren<ParticleSystem>();
        var windMain = wind.main;
        windMain.startSpeed = new ParticleSystem.MinMaxCurve(5f, box.center.y*box.size.y);
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
        //Debug.Log(bubbleRigid);

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Rigidbody>())
    //    {
    //        bubbleRigid = other.gameObject.GetComponent<Rigidbody>();
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.GetComponent<Rigidbody>())
    //    {
    //        bubbleRigid = null;
    //    }
    //}

    IEnumerator StopWindAfterASecond()
    {
        yield return new WaitForSeconds(1);
        wind.Stop();
    }

    
}
