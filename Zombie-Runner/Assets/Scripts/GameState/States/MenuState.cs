using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRun
{
    public class MenuState : State
    {
     

        public MenuState()
        {
            Debug.Log("Initialize MenuState");
        }

        public void Setup()
        {
            SceneManager.LoadScene(0);
        }

        public override void Update()
        {

        }

    }
}
