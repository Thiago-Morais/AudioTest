using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    public AudioSource[] soundList;
    public float[] amplitude;
    public int currentSoundIndex = 5;
    public int currentInstances, maxInstances;
    public List<AudioSource> instances;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        soundList = GetComponentsInChildren<AudioSource>();
        transform.parent.GetComponent<SoundSelector>().GetSoundEvents(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound()
    {
        if(currentInstances > maxInstances - 1)
        {
            GameObject aux = instances[0].gameObject;
            instances.RemoveAt(0);
            Destroy(aux);
            currentInstances--;
        }
            GameObject eventInstance = new GameObject("a = "+a++);
            AudioSource currentSound = eventInstance.AddComponent<AudioSource>();
            currentSound.clip = soundList[currentSoundIndex].clip;
            currentSound.Play();
            eventInstance.AddComponent<EventInstance>().creator = GetComponent<AudioEvent>();
            currentInstances++;

            if(currentSoundIndex == soundList.Length)
                currentSoundIndex = 0;
        soundList[currentSoundIndex].clip.GetData(amplitude, 0);
        print(amplitude);
    }
}
