using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ZombieRun
{
    public class Menu : MonoBehaviour
    {
        public Button mPlayButton;
        public Button mExitButton;
        
        public void Setup()
        {
            SceneManager.LoadScene(0);
        }

        private void Start()
        {
            GuiButtonActionManager.Instance.AssingActionToButton(ButtonAction.Exit, mExitButton);
            GuiButtonActionManager.Instance.AssingActionToButton(ButtonAction.Play, mPlayButton);
        }

        public void Update()
        {

        }

    }
}
