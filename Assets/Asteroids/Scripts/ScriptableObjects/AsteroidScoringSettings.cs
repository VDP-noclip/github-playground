using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Asteroids/ScoringSettings")]
public class AsteroidScoringSettings : ScriptableObject
{
    public int LargeAsteroidScore = 20;
    public int MediumAsteroidScore = 50;
    public int SmallAsteroidScore = 100;
    public int LargeSaucer = 200;
    public int SmallSaucer = 1000;

    public int SmallSaucerAppearsAfter = 40000;
    public int ExtraShipAfter = 10000;
}
