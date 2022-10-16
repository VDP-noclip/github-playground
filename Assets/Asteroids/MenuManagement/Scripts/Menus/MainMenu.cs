using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.MenuManagement
{
    public class MainMenu : Menu<MainMenu>
    {
        public bool fadeToPlay = true;                          // should it use the fading transition?
        [SerializeField] private float playDelay = 0.5f;        // # seconds before loading the gameplay screen
        [SerializeField] private TransitionFader transitionFaderPrefab;
        
        public void OnSettingsPressed()
        {
            print("SETTINGS");
            // SettingsMenu.Open();
        }

        public void OnCreditPressed()
        {
            // print("CREDITS");
            CreditsScreen.Open();
        }
        
        public void OnPlayPressed()
        {
            //if (fadeToPlay)
            //{
            //   StartCoroutine(OnPlayPressedRoutine());
            //}
            //else
            //{
                // LevelManager.LoadNextLevel();
                // GameMenu.Open();
            //}
            
            GameManager.Instance.StartGame();
            GameMenu.Open();
            
        }

        private IEnumerator OnPayPressedRoutine2()
        {
            GameMenu.Open();
            yield return new WaitForSeconds(1f);
            GameManager.Instance.StartGame();
        }
        
        private IEnumerator OnPlayPressedRoutine()
        {
            // print("ACTIVATE THE TRANSITION FADER");
            // TransitionFader.PlayTransition(transitionFaderPrefab);
            // LevelManager.LoadFirstLevel();
            // yield return new WaitForSeconds(playDelay);
            // GameMenu.Open();
            yield return null;
        }


        public override void OnBackPressed()
        {
            Application.Quit();
        }
    }
}