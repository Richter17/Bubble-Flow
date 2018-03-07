using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour {

    public delegate void HitGoalOrWall(bool isGoal);
    public static event HitGoalOrWall hitSomething;

    public float deviation;

    public static int points = 0;

    Rigidbody rigid;


    private Vector3 startPos;

    private void Awake()
    {
        if (hitSomething != null)
        {
            //Removing all events that are in the delegate, 
            //because it's static we have to remove all events from the source before we load the scene again
            System.Delegate[] deletegates = hitSomething.GetInvocationList();
            for (int i = 0; i < deletegates.Length; i++)
            {
                //Remove all event
                hitSomething -= deletegates[i] as HitGoalOrWall;
            }
        }
    }
    // Use this for initialization
    void Start () {

        rigid = GetComponent<Rigidbody>();
        startPos = transform.position;
        StartCoroutine(BubbleMove());
        hitSomething += LoseAndReturnToStart;
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

    void LoseAndReturnToStart(bool lost)
    {
        if(!lost)
        {            
            transform.position = startPos;
        }
    }



    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Win"))
        {
            if (hitSomething != null)
            {
                hitSomething(true);
            }
        }
        else
        {
            if (hitSomething != null)
            {
                hitSomething(false);
            }
            //Debug.Log("Pop! you lose");
        }
        
        //LevelManager.manager.Lose();
        //transform.position = startPos;
        //rigid.velocity = Vector3.zero;
    }
    
}
