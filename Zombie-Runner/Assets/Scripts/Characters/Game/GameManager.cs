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

        public GameStates gameState;

        private static GameManager m_Instance;
        private GameScreenManager GameScreenManager;

        private float initialFixedDelta;
        private float score;


        public bool lockCursor = true;
        private bool m_cursorIsLocked = true;

        private bool m_GameFinished = false;
        private bool m_IsPaused;


        public void CheckIsLocked(bool value)
        {
            m_cursorIsLocked = value;
        }

        public static GameManager Instance
        {
            get
            {
                return m_Instance;
            }

            set
            {
                m_Instance = value;
            }
        }


        void Awake()
        {
            Instance = this;
            Initialise();
            DontDestroyOnLoad(gameObject);
        }

        void Initialise()
        {
            initialFixedDelta = Time.fixedDeltaTime;
            InputManager input = new InputManager();
            StateManager stateManager = new StateManager();
            PlayerManager playerManager = new PlayerManager();
            playerManager.Initialize();
        }

        void Update()
        {
            StateManager.Instance.Update();
        }

        public void GameLogic()
        {

            if (InputManager.instance.PauseKeyIsPressed())
            {
                m_IsPaused = !m_IsPaused;
                Pause(m_IsPaused);
                SetCursorLock(!m_IsPaused);
            }
        }

        void FixedUpdate()
        {
            UpdateCursorLock();
        }

        public void UpdateCursorLock()
        {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (lockCursor)
                InternalLockUpdate();
        }

        public void SetCursorLock(bool value)
        {
            lockCursor = value;
            if (!lockCursor)
            {//we force unlock the cursor if the user disable the cursor locking helper
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        private void InternalLockUpdate()
        {
            if (CheckIfPaused())
            {
                m_cursorIsLocked = false;
            }
            else if (!CheckIfPaused())
            {
                m_cursorIsLocked = true;
            }

            if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
        }



        public bool CheckIfPaused()
        {
            return m_IsPaused;
        }

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


        public void ResetGame()
        {
            gameState = GameStates.Game;
            SetCursorLock(true);
            m_IsPaused = false;
            Pause(false);
        }

        public bool GameIsFinished()
        {
            return m_GameFinished;
        }

        public void GameOver()
        {
            m_GameFinished = true;
            UIManager.mInstance.Panels[UIManager.PanelElements.Winning].SetActive(true);
            //enemyManager.gameObject.SetActive(false);
            GameManager.Instance.gameState = GameStates.Gameover;

        }

    }
}
