using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticFan : MonoBehaviour {

    public float fanForce;
 //   public bool activateFan;
    public Rigidbody bubbleRigid;
    BoxCollider box;
    ParticleSystem wind;

    private void OnDrawGizmos()
    {
        box = GetComponentInChildren<FanArea1>().GetComponent<BoxCollider>();
        Matrix4x4 effectArea = Matrix4x4.TRS(transform.position, transform.rotation, box.size);
        Gizmos.matrix = effectArea;

        Gizmos.DrawWireCube(new Vector3(0, (box.center.y / box.size.y)), transform.localScale);
    }
    // Use this for initialization
    void Start () {
        box = GetComponentInChildren<FanArea1>().GetComponent<BoxCollider>();
        wind = GetComponentInChildren<ParticleSystem>();
        var windMain = wind.main;
        windMain.startSpeed = new ParticleSystem.MinMaxCurve(5f, box.center.y * box.size.y);
        wind.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (bubbleRigid)
        {
            //Debug.Log("push bubble");
            bubbleRigid.AddForce((bubbleRigid.transform.position - transform.position).normalized * fanForce * Time.deltaTime);
        }
    }
}
