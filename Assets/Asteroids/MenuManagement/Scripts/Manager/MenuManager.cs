using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Asteroids.MenuManagement
{
    public class MenuManager : MonoBehaviour
    {
        [Header("Menu Prefabs")]
        public MainMenu mainMenuPrefab;
        //
        // public SettingsMenu settingsMenuPrefab;
        //
        public CreditsScreen creditsScreenPrefab;
        
        public GameMenu gameMenuPrefab;

        // public PauseMenu pauseMenuPrefab;
        //
        // public LevelCompletedScreen levelCompletedScreen;
        //
        // public GameCompletedScreen gameCompletedScreen;
        
        
        [SerializeField] private Transform _menuParent;

        private Stack<Menu> _menuStack = new Stack<Menu>();

        private static MenuManager _instance;
        public static MenuManager Instance
        {
            get
            {
                return _instance;
            }
        }
        
        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
                InitializeMenu();
                DontDestroyOnLoad(gameObject);
            }
        }

        public void OpenMenu(Menu menuInstance)
        {
            if (menuInstance == null)
            {
                Debug.LogWarning("MENU MANAGER: opening invalid menu");
                return;
            }

            if (_menuStack.Count > 0)
            {
                foreach (Menu menu in _menuStack)
                {
                    menu.gameObject.SetActive(false);
                }
            }

            menuInstance.gameObject.SetActive(true);
            _menuStack.Push(menuInstance);
            
            print("STACK CONTAINS "+_menuStack.Count);
        }

        public void CloseMenu()
        {
            if (_menuStack.Count == 0)
            {
                Debug.LogWarning("MENU MANAGER: no menu to close");
                return;
            }

            Menu topMenu = _menuStack.Pop();
            topMenu.gameObject.SetActive(false);

            if (_menuStack.Count > 0)
            {
                Menu nextMenu = _menuStack.Peek();
                nextMenu.gameObject.SetActive(true);
            }
        }

        
        private void InitializeMenu()
        {
            
            if (_menuParent == null)
            {
                print("CREA MENUS GAME OBJECT");
                GameObject menuParentObject = new GameObject("Menus");
                menuParentObject.transform.position = Vector3.zero;
                _menuParent = menuParentObject.transform;
                DontDestroyOnLoad(_menuParent.gameObject);
            }

            // keeps all the menu active during the scene switch
            
            // Menu[] menuObjects = {mainMenuPrefab,settingsMenuPrefab,creditsScreenPrefab,gameMenuPrefab,pauseMenuPrefab,levelCompletedScreen,gameCompletedScreen};
            Menu[] menuObjects = {mainMenuPrefab,gameMenuPrefab,creditsScreenPrefab};

            for (int menu = 0; menu < menuObjects.Length; menu++)
            {
                Menu menuInstance = Instantiate(menuObjects[menu],_menuParent);
                
                if (menuObjects[menu] != mainMenuPrefab)
                {
                    menuInstance.gameObject.SetActive(false);
                }
                else
                {
                    OpenMenu(menuInstance);
                }
            }
            
        }
    }
}