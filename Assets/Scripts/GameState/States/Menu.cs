using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ZombieRun
{

    public class Menu : State
    {
  
        public Button m_PlayButton;
        public Button m_QuitButton;

        void Start()
        {
            GuiManager.Instance.AssingActionToButton(ButtonAction.Play, m_PlayButton);
            GuiManager.Instance.AssingActionToButton(ButtonAction.Exit, m_QuitButton);
        }

       

    }
}

