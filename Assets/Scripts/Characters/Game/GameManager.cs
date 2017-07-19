using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace ZombieRun
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager m_Instance;

        private float initialFixedDelta;
        private float score;
        private bool m_GameFinished = false;
        private bool m_GameIsPaused = false;

        public static GameManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        [SerializeField]
        public GameStates m_CurrentGameState;

   
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

        void Start()
        {
            initialFixedDelta = Time.fixedDeltaTime;
            new InputManager();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        public GameStates GetState()
        {
            return m_CurrentGameState;
        }

        public void TogglePause()
        {
            m_GameIsPaused = !m_GameIsPaused;
            Pause(m_GameIsPaused);
        }

        public void Pause(bool isPaused)
        {
            UIManager.Instance.TogglePausePanel(isPaused);
            PlayerManager.Instance.GetPlayer().getPlayerController().enabled = !isPaused;
            InputManager.instance.SetCursorLock(!isPaused);
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

        public bool IsGameFinished()
        {
            return m_GameFinished;
        }

        public void GameOver()
        {
            m_GameFinished = true;
            InputManager.instance.SetCursorLock(false);
            UIManager.Instance.ToggleWinPanel(true);
        }

        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
