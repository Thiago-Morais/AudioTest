using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

public class button : MonoBehaviour
{
    public int wat;
    void Start()
    {
        print("start");
    }
    [Button]
    public void SayName()
    {
        print(gameObject.name);
    }
}
