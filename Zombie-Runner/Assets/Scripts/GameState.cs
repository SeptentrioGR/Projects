using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class GameState : State
    {
        private GameObject Player;




        public GameState()
        {
            Debug.Log("Initialize GameState");
        }

        public override void Start()
        {
            PlayerManager.Instance.Initialize();
            GameManager.Instance.ResetGame();
            ItemManager.Instance.Initialize();
            CursorManager.Instance.Initialise();
        }

        public override void Update()
        {
            if (!GameManager.Instance.GameIsFinished())
            {
                CursorManager.Instance.Update();
                UIManager.mInstance.TogglePausePanel(GameManager.Instance.CheckIfPaused());


                if (UIManager.mInstance.Icons[UIManager.IconElements.Radio].enabled)
                {
                    Player.GetComponent<Character>().IAquireRadio();
                }

                PrefabManager.Instance.m_EnemyManager.Spawn();

                UIManager.mInstance.ChangeIconColor(Color.black);

                if (RadioClearArea.Instance.ClearArea)
                {
                    //Debug.Log("Clear Area");
                    UIManager.mInstance.ChangeIconColor(Color.green);
                }


            }

        }
    }
}