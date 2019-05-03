using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class EventInstance : MonoBehaviour
{
    AudioSource myClip;
    public AudioEvent creator;
    void Start()
    {
        myClip = GetComponent<AudioSource>();
        creator.GetComponent<AudioEvent>().instances.Add(myClip);
    }
    
    void Update()
    {
        if(!myClip.isPlaying)
        {
            creator.currentInstances--; 
            creator.GetComponent<AudioEvent>().instances.Remove(myClip);
            if (Application.isEditor)
                DestroyImmediate(gameObject);
            else
                Destroy(gameObject);
        }
    }
}
