using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private LevelManager _levelManager;
    private AsteroidFieldManager _asteroidFieldManager;

    protected override void Awake()
    {
        base.Awake();
        Debug.Log("AWAKE from GameManager");
        _levelManager = GameObject.FindObjectOfType<LevelManager>();
        _asteroidFieldManager = GameObject.FindObjectOfType<AsteroidFieldManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame()
    {
        AudioManager.Instance.PlayBackgroundMusic();
        AsteroidLevel gameLevel = _levelManager.GetLevel();
        _asteroidFieldManager.PlayLevel(gameLevel);
    }

    public void PlayNextLevel()
    {
        AsteroidLevel gameLevel = _levelManager.GetNextLevel();
        _asteroidFieldManager.PlayLevel(gameLevel);
    }


    public void GameOver()
    {
        //insert game over
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
