using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRun
{
    public class MenuState : MonoBehaviour
    {
     

        public MenuState()
        {
            Debug.Log("Initialize MenuState");
        }

        public void Setup()
        {
            SceneManager.LoadScene(0);
        }

        public void Update()
        {

        }

    }
}
