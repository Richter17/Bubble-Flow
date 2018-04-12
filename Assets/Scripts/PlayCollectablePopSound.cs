using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCollectablePopSound : MonoBehaviour {

    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ObjectiveBubble>()!=null)
        {
            audio.pitch = Random.Range(0.8f, 1.2f);
            audio.Play();
        }
    }
}
