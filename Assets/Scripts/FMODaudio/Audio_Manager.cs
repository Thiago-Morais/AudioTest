using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string eventRef;
    public FMODUnity.StudioEventEmitter eventEmitterRef;
    public FMOD.Studio.EventInstance musicEV;
    public string masterBusString;
    FMOD.Studio.Bus masterBus;
    public float vol = 0f, finalVol = 0f;
    float volFlute;
    FMOD.Studio.EventInstance eventInstance;

    // Start is called before the first frame update
    void Start()
    { /* 
        musicEV = FMODUnity.RuntimeManager.CreateInstance(eventRef);
        musicEV.start();  */
        //eventEmitterRef.Play();
        
        masterBus = FMODUnity.RuntimeManager.GetBus (masterBusString);
    }

    // Update is called once per frame
    void Update()
    {
        //masterBus.getVolume(out vol, out finalVol);
        
    }
    public void StartPlus()
    {
        eventEmitterRef.Play();
    }
    public void Stop()
    {
        eventEmitterRef.Stop();
    }
    public void RestartSong()
    {
        eventEmitterRef.Stop();
        eventEmitterRef.Play();
        //musicEV.start(); 
    }
    public void MuteMusic(bool mute)
    {   
        masterBus.setMute(mute); 
    }
    public void VolViolin(float vol)
    {
        eventEmitterRef.SetParameter("VolViolin", vol);
        //musicEV.setParameterValue("VolViolin", vol);
    }
    public void VolFlute(float vol)
    {
        eventEmitterRef.SetParameter("VolFlute", vol);
    }
    public void VolPizzato(float vol)
    {
        eventEmitterRef.SetParameter("VolPizzato", vol);
    }
    public void VolDoubleBass(float vol)
    {
        eventEmitterRef.SetParameter("VolDoubleBass", vol);
    }
    public void PlayPause()
    {
        bool paused;
        masterBus.getPaused(out paused);
        masterBus.setPaused(!paused);
    }
}
