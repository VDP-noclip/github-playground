using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Interval
{
    public float Lower = 0f;
    public float Upper = 1f;
    
    public float Random()
    {
        float width = Upper - Lower;
        return UnityEngine.Random.value * width + Lower;
    }
}
