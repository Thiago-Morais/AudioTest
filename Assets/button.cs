using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyButtons;

public class button : MonoBehaviour
{
    public int wat;
    [Button]
    public void SayName()
    {
        print(gameObject.name);
    }
}
