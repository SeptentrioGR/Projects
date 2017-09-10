using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun
{

    public enum GameState
    {
        Menu,Game
    }

    public enum GameLevel
    {
        Main = 0,
        Game = 1
    }


    public class GameManager : MonoBehaviour
    {
        private static GameManager m_Instance;

        private float initialFixedDelta;
        private float score;
        private bool m_GameFinished;
        [HideInInspector]
        public static bool m_GameIsPaused;

        private GameState mCurrentGameState;

        public GameState GetGameState()
        {
            return mCurrentGameState;
        }

        //===========================================================================
        public static GameManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        //===========================================================================
        void Awake()
        {
            if (m_Instance == null)
            {
                m_Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (m_Instance != this)
            {
                Destroy(this.gameObject);
                return;
            }
        }
        public void SetGameState(GameState state)
        {
            mCurrentGameState = state;
        }
        //===========================================================================
        void Start()
        {
            initialFixedDelta = Time.fixedDeltaTime;
            new InputManager();
        }

        //===========================================================================
        void Update()
        {
            InputManager.Instance.Update();

            if (StartingLoadingScene)
            {
                Debug.Log(async.progress);
                if(async.progress >= 0.9f)
                {
                    ActivateScene();
                }
            }

        }

        //===========================================================================
        public void TogglePause()
        {
            Player player = PlayerManager.Instance.GetPlayer().GetComponent<Player>();
            m_GameIsPaused = !m_GameIsPaused;
            GameObject panel = PrefabManager.Instance.GetItemInList("PauseMenu");
            panel.SetActive(!panel.activeSelf);
            Pause(m_GameIsPaused);
            player.getPlayerController().enabled = !m_GameIsPaused;
            MouseCursorHandler.Instance.ToggleMouseLock();
        }

        //===========================================================================
        public void Pause(bool isPaused)
        {
            if (isPaused)
            {
                Time.timeScale = 0;
                Time.fixedDeltaTime = 0;
            
            }
            else if (!isPaused)
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = initialFixedDelta;
            }
        }

        //===========================================================================
        public bool IsGameFinished()
        {
            return m_GameFinished;
        }

        //===========================================================================
        public void GameOver()
        {
            m_GameFinished = true;         
            ToggleWinPanel();
        }

        public void StartGame()
        {
            levelName = "Game";
            StartLoading();
            GameManager.Instance.SetGameState(GameState.Game);
        }
 
        //===========================================================================
        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //===========================================================================
        public void GoToMenu()
        {
            levelName = "Main";
            StartLoading();
            GameManager.Instance.SetGameState(GameState.Menu);
        }

        //===========================================================================
        public void ToggleWinPanel()
        {
            Helicopter.Instance.Silence();
            MouseCursorHandler.Instance.ToggleMouseLock();
            GameObject panel = PrefabManager.Instance.GetItemInList("WinMenu");
            panel.SetActive(!panel.activeSelf);
        }

        public string levelName;
        AsyncOperation async;
        public bool StartingLoadingScene;

        public void StartLoading()
        {
            if (!StartingLoadingScene)
            {
                StartingLoadingScene = !StartingLoadingScene;
                StartCoroutine("load");
            }
        }

        IEnumerator load()
        {
            Debug.LogWarning("ASYNC LOAD STARTED - " +
               "DO NOT EXIT PLAY MODE UNTIL SCENE LOADS... UNITY WILL CRASH");
            async = SceneManager.LoadSceneAsync(levelName);
            async.allowSceneActivation = false;
            yield return async;
        }

        public void ActivateScene()
        {
            StartingLoadingScene = false;
            async.allowSceneActivation = true;
        }

    }
}
