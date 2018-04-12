using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBubble : ColliderObject {

    float squareLength = 1.5f;
    float movingSpeed = 0.01f;


    Vector3 startPos;
    Vector3 move = Vector3.zero;
    bool waitForFirstMove = false;
    private void Awake()
    {
        LevelManager.objectiveBubbles++;
        startPos = transform.position;
        StartCoroutine(MoveVectorSetter());
    }

    private void FixedUpdate()
    {
        if (!waitForFirstMove) return;
        transform.position = Vector3.Lerp(transform.position, move, movingSpeed);
    }

    IEnumerator MoveVectorSetter()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            waitForFirstMove = true;
            move.x = Random.Range(startPos.x - (squareLength / 2), startPos.x + (squareLength / 2));
            move.y = Random.Range(startPos.y - (squareLength / 2), startPos.y + (squareLength / 2));
        }
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        
        //base.OnTriggerEnter(other);
        if (canBeObtained)
        {
            LevelManager.objectiveBubbles--;
            Debug.Log(LevelManager.objectiveBubbles + " bubbles left");
            Destroy(gameObject);
        }
    }
}
