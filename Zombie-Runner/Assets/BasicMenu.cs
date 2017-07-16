using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ZombieRun
{

    public class BasicMenu : MonoBehaviour
    {

        public Button m_PlayButton;
        public Button m_QuitButton;

        private void Awake()
        {

        }



        void Start()
        {    
            m_PlayButton.onClick.AddListener(Play);
            m_QuitButton.onClick.AddListener(Exit);
        }

        void Update()
        {

        }

        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void ResetGame()
        {
            GameManager.Instance.ResetGame();
            SceneManager.LoadScene(1);
        }
    }
}

