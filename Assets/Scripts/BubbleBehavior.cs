using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour {

    Rigidbody rigid;
    public float leftDeviation, rightDeviation;

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

    IEnumerator BubbleMove()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 4f));
            rigid.AddForce(Vector3.right * Random.Range(leftDeviation, rightDeviation));
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Pop! you lose");
        LevelManager.manager.Lose();
        transform.position = startPos;
        rigid.velocity = Vector3.zero;
    }
}
