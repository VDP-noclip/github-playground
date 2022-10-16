using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Asteroids/Asteroid Field Parameters")]
public class AsteroidFieldParameters : ScriptableObject
{
    [Header("Large Asteroid")] 
    public float LargeAsteroidSpeed = 3f;
    public float LargeAsteroidScale = 1f;

    [Header("Medium Asteroid")] 
    public float MediumAsteroidSpeed = 3f;
    public float MediumAsteroidScale = 1f;
    
    [Header("Small Asteroid")] 
    public float SmallAsteroidSpeed = 3f;
    public float SmallAsteroidScale = 1f;

}
