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
            InputManager input = new InputManager();
        }

        //===========================================================================
        void Update()
        {
            InputManager.Instance.Update();
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

        //===========================================================================
        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //===========================================================================
        public void ToggleWinPanel()
        {
            GameObject panel = PrefabManager.Instance.GetItemInList("WinMenu");
            panel.SetActive(!panel.activeSelf);
        }    

    }
}
