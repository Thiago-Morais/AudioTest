using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSelector : MonoBehaviour
{
    public List<GameObject> events;
    public void GetSoundEvents(Transform eventTransform)
    {
        /* 
        foreach (Transform child in transform)
            if(child.GetComponent<AudioEvent>())
                if(child.GetComponent<AudioEvent>().soundList.Length > 0)
                    events.Add(child.gameObject); 
        */
        events.Add(eventTransform.gameObject); 
    }
}
