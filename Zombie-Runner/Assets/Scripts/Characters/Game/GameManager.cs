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
        private GameScreenManager GameScreenManager;

        private float initialFixedDelta;
        private float score;



        private bool m_GameFinished = false;
        private bool m_IsPaused;

     
        State m_CurrentState;

        GameState GameState;
        MenuState MenuState;
        GameOverState GameOverState;
        Dictionary<GameStates, State> ListOfStates = new Dictionary<GameStates, State>();

        public static GameManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public State GetState()
        {
            return m_CurrentState;
        }

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

            GameState = new GameState();
            MenuState = new MenuState();
            GameOverState = new GameOverState();

            ListOfStates.Add(GameStates.Game, GameState);
            ListOfStates.Add(GameStates.Menu, MenuState);
            ListOfStates.Add(GameStates.Gameover, GameOverState);

            new InputManager();

           SetState(GameStates.Menu);

        }

        public void SetState(GameStates state)
        {
            m_CurrentState = ListOfStates[state];
            m_CurrentState.Start();
        }

        void Update()
        {
            m_CurrentState.Update();

            if (InputManager.instance.PauseKeyIsPressed())
            {
                m_IsPaused = !m_IsPaused;
                Pause(m_IsPaused);
                InputManager.instance.SetCursorLock(!m_IsPaused);
            }


            if (CheckIfPaused())
            {
                InputManager.instance.SetCursorLock(false);
            }
            else if (!CheckIfPaused())
            {
                InputManager.instance.SetCursorLock(true);
            }

            InputManager.instance.Update();
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
            SetState(GameStates.Game);
            InputManager.instance.ResetGame();
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
            SetState(GameStates.Gameover);
            UIManager.Instance.ToggleWinPanel(true);
            //enemyManager.gameObject.SetActive(false);
        
        }

      

    }
}
