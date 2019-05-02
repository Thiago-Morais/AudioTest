using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInstanceFMOD : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string eventRef;
    FMOD.Studio.EventInstance musicEV;
    // Start is called before the first frame update
    void Start()
    {
        bool paused;
        musicEV.getPaused(out paused);
        musicEV = FMODUnity.RuntimeManager.CreateInstance(eventRef);
        
        //musicEV.start(); 
        musicEV.setParameterValue("VolViolin", 1f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
