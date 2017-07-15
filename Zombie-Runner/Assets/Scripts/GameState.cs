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
            CursorManager.Instance.Initialise();
            UIManager.Instance.Initialize();
            ItemManager.Instance.Initialize();
        }

        public override void Update()
        {
            CursorManager.Instance.Update();
            UIManager.Instance.TogglePausePanel(GameManager.Instance.CheckIfPaused());


            if (UIManager.Instance.Icons[UIManager.IconElements.Radio].enabled)
            {
                Player.GetComponent<Character>().IAquireRadio();
            }

            PrefabManager.Instance.m_EnemyManager.Spawn();

            UIManager.Instance.ChangeIconColor(Color.black);

            if (RadioClearArea.Instance.ClearArea)
            {
                //Debug.Log("Clear Area");
                UIManager.Instance.ChangeIconColor(Color.green);
            }

            PlayerStatusWidget.Instance.RefreshContent();

        }
    }
}