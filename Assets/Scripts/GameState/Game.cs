using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun
{
    public class Game : MonoBehaviour
    {
        public HouseChecked[] m_ListOfHouses;
        public EnemyManager mEnemyManager;
        public float min;
        public float sec;
        public float speed;
        private void Awake()
        {
            Setup();
         
        }

        public void Setup()
        {
            PlayerManager players = new PlayerManager();
            ItemManager items = new ItemManager(GameConfig.Instance.GetItemToSpawn(), GameConfig.Instance.GetItemSpawnLocations());
            new CountDown(min,sec,speed);
            mEnemyManager.Initialize();
            InventoryManager inventory = new InventoryManager();
            GameManager.m_GameIsPaused = false;
            GameManager.Instance.SetGameState(GameState.Game);
            NarationManager.Instance.Intro();
            NarationManager.Instance.StartNaration();
        }

        public void Update()
        {
            Character player = PlayerManager.Instance.GetPlayer();

            if(player.mHealth <= 0)
            {
                GameManager.Instance.ResetGame();
            }

            if (RadioIconWidget.Instance.isEnabled())
            {
                InventoryManager.Instance.AddItem("Radio");
            }

            mEnemyManager.Update();
      

            RadioIconWidget.Instance.ChangeIconColor(Color.black);

            if (!ClockWidget.Instance.Counting())
            {
                if (RadioClearArea.Instance.ClearArea)
                {
                    RadioIconWidget.Instance.ChangeIconColor(Color.green);
                }
            }
            else if (ClockWidget.Instance.Counting())
            {
                RadioIconWidget.Instance.Enabled(false);
            }

            PlayerStatusWidget.Instance.RefreshContent();
               
            if (InventoryManager.Instance.HasItem("Radio"))
                RadioIconWidget.Instance.Enabled(true);
            else
                RadioIconWidget.Instance.Enabled(false);
        }
    }
}