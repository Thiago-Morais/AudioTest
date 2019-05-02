using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstance : MonoBehaviour
{
    AudioSource myClip;
    public AudioEvent creator;
    void Start()
    {
        myClip = GetComponent<AudioSource>();
        creator.GetComponent<AudioEvent>().instances.Add(myClip);
    }
    // Update is called once per frame
    void Update()
    {
        if(!myClip.isPlaying)
        {
            creator.currentInstances--; 
            creator.GetComponent<AudioEvent>().instances.Remove(myClip);
            Destroy(gameObject);
        }
    }
}
