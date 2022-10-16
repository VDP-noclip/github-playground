using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.MenuManagement
{
        
    public class CreditsScreen : Menu<CreditsScreen>
    {
        public override void OnBackPressed()
        {
            base.OnBackPressed();
                
            // Your custom behavior
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnBackPressed();
            }
        }
    }
}
