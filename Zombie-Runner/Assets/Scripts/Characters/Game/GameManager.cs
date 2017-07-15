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
            m_Instance = this;

            GameState = new GameState();
            MenuState = new MenuState();

            ListOfStates.Add(GameStates.Game, GameState);
            ListOfStates.Add(GameStates.Menu, MenuState);

            SetState(GameStates.Game);

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            initialFixedDelta = Time.fixedDeltaTime;
            InputManager input = new InputManager();
            PlayerManager playerManager = new PlayerManager();    
            m_CurrentState.Start();
        }

        public void SetState(GameStates state)
        {
            m_CurrentState = ListOfStates[state];
        }

        void Update()
        {
            m_CurrentState.Update();

            if (CheckIfPaused())
            {
                InputManager.instance.SetCursorLock(false);
            }
            else if (!CheckIfPaused())
            {
                InputManager.instance.SetCursorLock(true);
            }
        }

        public void GameLogic()
        {

            if (InputManager.instance.PauseKeyIsPressed())
            {
                m_IsPaused = !m_IsPaused;
                Pause(m_IsPaused);
                InputManager.instance.SetCursorLock(!m_IsPaused);
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
            UIManager.Instance.Panels[UIManager.PanelElements.Winning].SetActive(true);
            //enemyManager.gameObject.SetActive(false);
        
        }

    }
}
