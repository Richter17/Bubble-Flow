using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour {

    public float deviation;

    public static int points = 0;

    Rigidbody rigid;


    private Vector3 startPos;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        startPos = transform.position;
        StartCoroutine(BubbleMove());
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    private void FixedUpdate()
    {
    }

    IEnumerator BubbleMove()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 4f));
            rigid.AddForce(Vector3.right * Random.Range(-deviation, deviation));
            //Vector3 velo = rigid.velocity;
            //velo.x /= stopperMulVal;
            //rigid.velocity = velo;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Pop! you lose");
        //LevelManager.manager.Lose();
        //transform.position = startPos;
        //rigid.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        Objects obj = other.GetComponent<Objects>();
        if(obj)
        {
            points++;
            Destroy(obj.gameObject);
        }
    }
}
