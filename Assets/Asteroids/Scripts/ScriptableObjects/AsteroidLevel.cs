using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Asteroids/Level")]
public class AsteroidLevel : ScriptableObject
{
    public int NumberOfLargeAsteroids;
    public int NumberOfBigSaucer;
    public int NumberOfSmallSaucer;

    public float LargeAsteroidSpeedModifier = 1.0f;
    public float MediumAsteroidSpeedModifier = 1.0f;
    public float SmallAsteroidSpeedModifier = 1.0f;

    [Range(0.25f,0.9f)]
    public float BigSaucerThreshold = .5f;
    
    [Range(0.25f,0.9f)]
    public float SmallSaucerThreshold = .5f;
}
