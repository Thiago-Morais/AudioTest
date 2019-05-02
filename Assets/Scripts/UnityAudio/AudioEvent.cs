using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour
{
    [Header("AUDIO VARIATIONS")]
    public ShuffleTypes shuffleType;
    public float pithVariationSt;
    [Header("Debug")]
    public AudioSource[] soundList;
    public int[] playOrder;
    public List<AudioSource> instances;
    public int currentSoundIndex;
    public int currentInstances, maxInstances = 5;
    public List<Amplitudes> amplitudes;
    public class Amplitudes
    {
        public float[] amplitude = new float[2];
    }
    public bool randomized = false;
    int a;
    // Start is called before the first frame update
    void Start()
    {
        soundList = GetComponentsInChildren<AudioSource>();
        transform.parent.GetComponent<SoundSelector>().GetSoundEvents(transform);
        playOrder = new int[soundList.Length];
        for(int i = 0; i < playOrder.Length; i++)
            playOrder[i] = i;
    }
    public void PlaySound()
    {
        if(currentInstances > maxInstances - 1)                     /* VERIFICA SE CHEGOU NO LIMITE MAXIMO DE INSTANCIAS E APAGA A PRIMEIRA */
        {
            GameObject aux = instances[0].gameObject;                       //  Cria o ponteiro
            instances.RemoveAt(0);                                          //Remove o elemento da lista
            Destroy(aux);                                                   //Destroi o Objeto
            currentInstances--;                                             //Diminue o contador
        }

        GameObject eventInstance = new GameObject("a = "+a++);                                  //Cria a instancia
        eventInstance.transform.parent = gameObject.transform;                                  //Faz com que a instancia seja filha desse objeto
        AudioSource currentSound = eventInstance.AddComponent<AudioSource>();                   //Adiciona uma fonte de audio
        currentSound = Shuffle();                                                               //Ajusta as configurações dessa fonte com base na função Shuffle
        PitchChange(currentSound);                                                              //Altera o pitch do audio
        currentSound.Play();                                                                    //Da Play no clip
        eventInstance.AddComponent<EventInstance>().creator = GetComponent<AudioEvent>();       //Adiciona o Script da instancia e da a referencia desse objeto
        currentInstances++;

                
        /* for(int i = 0; i < instances.Count; i++)
        {
            instances[i].clip.GetData(Amplitudes[i].amplitude, instances[instances.Count-1].timeSamples);
            print(amplitude[0]);
        } */
    }
    public enum ShuffleTypes 
    {
        NoShuffle, RandomOnce, RandomInTheStart, FullRandom
    }

    AudioSource Shuffle()
    {
        if(shuffleType == ShuffleTypes.NoShuffle)                                       /* NÃO EMBARALHA, REPRODUZ NA SEQUENCIA ORIGINAL */
        {
            if(currentSoundIndex == soundList.Length)
                currentSoundIndex = 0;                                                      //Volta pra o começo da lista
            return soundList[currentSoundIndex++];                                          //Retorna o som e Aumenta para a proxima reprodução
        }
        else if(shuffleType == ShuffleTypes.RandomOnce)                                 /* EMBARALHA APENAS UMA VEZ E REPRODUZ EM SEQUENCIA */
        {
            if(currentSoundIndex == playOrder.Length)
                currentSoundIndex = 0;                                                      //Volta pra o começo da lista
            if(!randomized)                                                                 //Verifica se Ja Foi embaralhado
            {
                randomized = true;
                currentSoundIndex = 0;                                                      //Volta pra o começo da lista
                RandomizeIntArray(playOrder);                                               //Embaralha
            }            
            return soundList[playOrder[currentSoundIndex++]];                               //Retorna o som com base na NOVA Lista de Reprodução e Aumenta para a proxima reprodução
        }
        else if(shuffleType == ShuffleTypes.RandomInTheStart)                           /* EMBARALHA SEMPRE QUE COMEÇAR A SEQUENCIA NOVAMENTE */
        {
            if(currentSoundIndex == playOrder.Length)
                currentSoundIndex = 0;                                                      //Volta pra o começo da lista
            if(currentSoundIndex == 0)
                RandomizeIntArray(playOrder);                                               //Embaralha
            return soundList[playOrder[currentSoundIndex++]];                               //Retorna o som com base na NOVA Lista de Reprodução e Aumenta para a proxima reprodução
        }
        else                                                                            /* EMBARALHA SEMPRE QUE FOR TOCAR UM SOM */
        {
            RandomizeIntArray(playOrder);                                                   //Embaralha
            if(currentSoundIndex == playOrder.Length)
                currentSoundIndex = 0;                                                      //Volta pra o começo da lista
            return soundList[playOrder[currentSoundIndex++]];                               //Retorna o som com base na NOVA Lista de Reprodução e Aumenta para a proxima reprodução
        }
    }
    void PitchChange(AudioSource audio)                                                 /* ALTERA O PITCH DO AUDIOSURCE RECEBIDO */
    {
        audio.pitch = 1 + Random.Range(-pithVariationSt/12, pithVariationSt/12);            //Converte a variação de pitch de Oitavas para Semitons e altera o AudioSource recebido
    }
    void RandomizeIntArray(int[] array)                                                 /* EMBARALHA A LISTA DE REPRODUÇÃO */
    {
        for (int j = 0; j < 2; j++)
            for(int i = 0; i < array.Length; i++)
            {
                int rand = Random.Range(i, array.Length);
                int aux = array[i];
                array[i] = array[rand];
                array[rand] = aux;
            }
    }
}
