using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSoundType : MonoBehaviour
{
    public bool SoundType = true;
    public GameObject fmodSound, unitySound;
    public GameObject tempFMODsound, tempUnitySound;
    public Transform HUD;
    // Start is called before the first frame update
    void Start()
    {
        //Toggle();
    }
    public void Toggle()
    {
        if(SoundType)
        {
            Destroy(tempFMODsound);
            tempUnitySound = Object.Instantiate(unitySound, HUD);
            SoundType = !SoundType;
        }
        else
        {
            Destroy(tempUnitySound);
            tempFMODsound = Object.Instantiate(fmodSound, HUD);
            SoundType = !SoundType;
        }
    }
}
