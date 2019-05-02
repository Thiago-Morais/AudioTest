using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager1 : MonoBehaviour
{
    public AudioSource musicRef;

    // Start is called before the first frame update
    void Start()
    { /* 
        musicEV = FMODUnity.RuntimeManager.CreateInstance(eventRef);
        musicEV.start();  */
        //eventEmitterRef.Play();
        
        //musicRef.Play();
        //masterBus = FMODUnity.RuntimeManager.GetBus (masterBusString);
    }

    // Update is called once per frame
    void Update()
    {
        //masterBus.getVolume(out vol, out finalVol);
        
    }
    public void StartPlus()
    {
        musicRef.Play();
    }
    public void Stop()
    {
        musicRef.Stop();
    }
    public void RestartSong()
    {
        musicRef.Stop();
        musicRef.Play();
        //musicEV.start(); 
    }
    public void MuteMusic(bool mute)
    {   
        //masterBus.setMute(mute); 
        musicRef.mute = !musicRef.mute;
    }
    /* public void VolViolin(float vol)
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
    } */
    public void PlayPause()
    {
        if(musicRef.isPlaying)
            musicRef.Pause();
        else
            musicRef.Play();
    }
}
