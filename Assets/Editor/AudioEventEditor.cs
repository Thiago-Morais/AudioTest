/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioEvent))]
public class AudioEventEditor : Editor
{
    public void OnInspectorGUI()
    {
        AudioEvent myAudioEvent = (AudioEvent) target;
        AudioEvent saveScript = myAudioEvent;

        GUILayout.BeginHorizontal();
            GUILayout.Space(Screen.width/5*2);
            if (GUILayout.Button("ResetEvent"))
                myAudioEvent = saveScript;
            if (GUILayout.Button("SaveEvent"))
                saveScript = myAudioEvent;        
        GUILayout.EndHorizontal();

        myAudioEvent.shuffleType = (AudioEvent.ShuffleTypes) EditorGUILayout.EnumPopup("Shuffle Type", myAudioEvent.shuffleType);
        myAudioEvent.pithVariationSt = EditorGUILayout.FloatField("Pitch Variation st", myAudioEvent.pithVariationSt);
        
        GUILayout.BeginHorizontal();
            GUILayout.Space(Screen.width/2);
            if (GUILayout.Button("Play Sound"))
            {
                myAudioEvent.PlaySound();
            }
        GUILayout.EndHorizontal();
    }
}
 */