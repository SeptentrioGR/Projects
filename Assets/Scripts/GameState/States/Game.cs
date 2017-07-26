using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZombieRun
{
    public class Game : State
    {

        public HouseChecked[] m_ListOfHouses;

        private void Awake()
        {
            Setup();
        }

        public void Setup()
        {
            new PlayerManager();       
            new ItemManager(GameConfig.Instance.GetItemToSpawn(), GameConfig.Instance.GetItemSpawnLocations());
            new CountDown(60, 00, 1);
            EnemyManager.Instance.Initialize();
            InputManager.instance.SetCursorLock(true);

        }

        public void Update()
        {
            Character player = PlayerManager.Instance.GetPlayer().GetComponent<Character>();

            if (RadioIconWidget.Instance.isEnabled())
            {
                player.IAquireRadio();
            }

            EnemyManager.Instance.Spawn();

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

            if (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("Vertical") < -0.5f)
            {
                MapWidget.Instance.Enabled(false);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                MapWidget.Instance.Toggle();
            }


            InputManager.instance.Update();
        }

    }
}