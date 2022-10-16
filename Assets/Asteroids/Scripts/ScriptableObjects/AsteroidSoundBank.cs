using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Asteroids/SoundBank")]
public class AsteroidSoundBank : ScriptableObject
{
    public AudioClip LargeAsteroidExplosion;
    public AudioClip MediumAsteroidExplosion;
    public AudioClip SmallAsteroidExplosion;
    public AudioClip ExtraShip;
    public AudioClip Fire;
    public AudioClip BigSaucer;
    public AudioClip SmallSaucer;
    public AudioClip Thrust;
    
    public AudioClip QuietBeat;
    public AudioClip ExcitingBeat;

    public float QuietBeatTiming = 1f;
    public float ExcitingBeatTiming = .5f;
}