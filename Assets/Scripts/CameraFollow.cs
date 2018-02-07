﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float slingeness;
    private Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, slingeness * Time.deltaTime);
	}
}
