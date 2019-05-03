using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour 
{
    public int experience;
    public int Level
    {
        get { return experience / 750; }
    }
    public int lv;

    void Update()
    {
        lv = experience / 750;
    }
}