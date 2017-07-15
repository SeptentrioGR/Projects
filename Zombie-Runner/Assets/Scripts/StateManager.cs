using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun
{
    public class StateManager
    {
        public static StateManager m_Instance;

        State m_CurrentState;

        GameState GameState;
        MenuState MenuState;
        Dictionary<GameStates, State> ListOfStates = new Dictionary<GameStates, State>();

        public static StateManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public StateManager()
        {
            m_Instance = this;
        }

        public void SetGameState(State gameState)
        {
            m_CurrentState = gameState;
        }

        public void Initialize()
        {
            GameState = new GameState();
            MenuState = new MenuState();

            ListOfStates.Add(GameStates.Game, GameState);
            ListOfStates.Add(GameStates.Menu, MenuState);
        }


        public void Update()
        {
            if (m_CurrentState != null)
            {
                m_CurrentState.Update();
            }
        }
    }
}