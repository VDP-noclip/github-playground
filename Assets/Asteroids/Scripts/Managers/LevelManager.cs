using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private AsteroidLevel[] asteroidLevels;

    private int _currentLevel = 0;
    
    public void Reset()
    {
        _currentLevel = 0;
    }

    public AsteroidLevel GetLevel()
    {
        return asteroidLevels[_currentLevel];
    }

    public AsteroidLevel GetNextLevel()
    {
        _currentLevel = Mathf.Min(_currentLevel + 1, asteroidLevels.Length - 1);
        return asteroidLevels[_currentLevel];
    }
}
