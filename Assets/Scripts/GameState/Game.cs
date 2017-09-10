using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRun
{
    public class Game : MonoBehaviour
    {
        private static Game m_Instance;
        public static Game Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public HouseChecked[] m_ListOfHouses;
        public EnemyManager mEnemyManager;
        public float min;
        public float sec;
        public float speed;

        public Helicopter m_RescueHelicopter;
        private bool m_HittingTheEnemy = false;


        public float TimeSincePlayedSpookySound = 0;



        public bool HittingTheEnemy
        {
            get
            {
                return m_HittingTheEnemy;
            }
            set
            {
                m_HittingTheEnemy = value;
            }
        }

        public void Start()
        {
            ObjecttiveWidget.Instance.setObjective("Find and Retrieve new Radio");
            m_Instance = this;
            new PlayerManager();
            new ItemManager(GameConfig.Instance.GetItemToSpawn(), GameConfig.Instance.GetItemSpawnLocations());
            new CountDown(min,sec,speed);
            mEnemyManager.Initialize();
            new InventoryManager();
            GameManager.m_GameIsPaused = false;
            GameManager.Instance.SetGameState(GameState.Game);
            NarationManager.Instance.Intro();
            NarationManager.Instance.StartNaration();
            ItemManager.Instance.SpawnRadio();
            EnemyManager.Instance.EnableSpawning(true);
        }

        public void Update()
        {
            Character player = PlayerManager.Instance.GetPlayer();

            if (player.Health <= 0)
            {
                GameManager.Instance.ResetGame();
            }

            if (GameManager.Instance.IsGameFinished())
            {
                EnemyManager.Instance.EnableSpawning(false);
                mEnemyManager.DeleteEnemies();
            }

            mEnemyManager.Update();


            RadioIconWidget.Instance.ChangeIconColor(Color.black);

            if (!ClockWidget.Instance.Counting())
            {
                if (RadioClearArea.Instance.AreaIsClear)
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
            {
                ObjecttiveWidget.Instance.setObjective("Find A Clear Area To Call Help! (hint: Radio Icon turns Green)");
                RadioIconWidget.Instance.Enabled(true);
            }
            else                RadioIconWidget.Instance.Enabled(false);

            bool RescueHelicopterOnItsWay = Helicopter.Instance.m_Called;
            if (RescueHelicopterOnItsWay)
            {
                ObjecttiveWidget.Instance.setObjective("Wait for Extraction!");
                ClockWidget.Instance.StartTimer();
                mEnemyManager.IncreaseEnemiesChaseSpeed();
            }

            if (CountDown.Instance.TimeIsUp())
            {
                ObjecttiveWidget.Instance.setObjective("Quick! Jump into the helicopter!");
                Helicopter.Instance.GoToArea();
            }

         

            if (HittingTheEnemy && player.GetComponent<Player>().m_Flashlight.LightIsPowered())
            {
                player.GetComponent<Player>().m_Flashlight.mBatteryThreshold = -25;
            }
            else if (!HittingTheEnemy && !player.GetComponent<Player>().m_Flashlight.LightIsPowered())
            {
                player.GetComponent<Player>().m_Flashlight.mBatteryThreshold = 5;
            }
            else if (!player.GetComponent<Player>().m_Flashlight.LightIsPowered())
            {
                player.GetComponent<Player>().m_Flashlight.mBatteryThreshold = 5;
            }

            if(TimeSincePlayedSpookySound > 0)
            {
                TimeSincePlayedSpookySound -= Time.deltaTime;
            }

            TimeSincePlayedSpookySound = Mathf.Clamp(TimeSincePlayedSpookySound, 0, 2);
        }
    }
}