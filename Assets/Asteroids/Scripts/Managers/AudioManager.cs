using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AsteroidSoundBank _asteroidSoundBank;
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _asteroidSound;
    [SerializeField] private AudioSource _missileSound;
    [SerializeField] private AudioSource _smallSaucerSound;
    [SerializeField] private AudioSource _bigSaucerSound;
    [SerializeField] private AudioSource _thrustSound;

    public void PlayMissileSound()
    {
        _missileSound.PlayOneShot(_asteroidSoundBank.Fire);
    }
    
    public void PlayThrustSound()
    {
        _thrustSound.PlayOneShot(_asteroidSoundBank.Thrust);
    }

    public void PlayBackgroundMusic()
    {
        
    }
    public void PlayAsteroidExplosion(AsteroidController.Size size)
    {
        switch (size)
        {
            case AsteroidController.Size.Large:
                _asteroidSound.PlayOneShot(_asteroidSoundBank.LargeAsteroidExplosion);
                break;
            case AsteroidController.Size.Medium:
                _asteroidSound.PlayOneShot(_asteroidSoundBank.MediumAsteroidExplosion);
                break;
            case AsteroidController.Size.Small:
                _asteroidSound.PlayOneShot(_asteroidSoundBank.SmallAsteroidExplosion);
                break;
        }
        
    }
}
