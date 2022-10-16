using System;
using System.Collections;
using System.Collections.Generic;
using POLIMIGameCollective;
using UnityEngine;

namespace Asteroids.MenuManagement
{
    
    public class GameMenu : Menu<GameMenu>
    {
        // Start is called before the first frame update

        [SerializeField] private GameObject[] shipIcons;

        [SerializeField] private TMPro.TextMeshProUGUI _textMeshPro;
        
        //Bast way to update score
        public void OnEnable()
        {
            EventManager.StartListening("UpdateScore", UpdateScore);
        }
        
        
        
        public void UpdateScore(int score)
        {
            EventManager.StopListening("UpdateScore", UpdateScore);
            _textMeshPro.text = score.ToString("D8");
            EventManager.StartListening("UpdateScore", UpdateScore);
        }

        public void UpdateNumberOfShips(int numberOfShips)
        {
            for (int i = 0; i < shipIcons.Length; i++)
            {
                shipIcons[i].SetActive(i<numberOfShips);
            }
        }

        #region UNITY_EDITOR
        
        #if UNITY_EDITOR
        
        private int _score = 0;
        private int _numberOfShips = 3;


        private void Update()
        {
            if (Input.GetKey(KeyCode.Alpha0))
            {
                _score = _score + 20;

                UpdateScore(_score);
            }

            if (Input.GetKeyDown(KeyCode.Alpha9))
                _numberOfShips = Mathf.Min(_numberOfShips + 1,10);
            if (Input.GetKeyDown(KeyCode.Alpha8))
                _numberOfShips = Mathf.Max(_numberOfShips - 1,0);
            UpdateNumberOfShips(_numberOfShips);
        }
        #endif

        #endregion
    }
}

