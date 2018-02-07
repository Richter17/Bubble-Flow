using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour {

    Rigidbody rigid;
    public float leftDeviation, rightDeviation;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator BubbleMove()
    {
        yield return new WaitForSeconds(Random.Range(1.5f, 4f));
        rigid.AddForce(Vector3.right * Random.Range(leftDeviation, rightDeviation));
    }
}
