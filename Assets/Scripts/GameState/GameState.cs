using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class GameState : MonoBehaviour
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
            new CountDown(60, 99, 1);
            EnemyManager.Instance.Initialize();
            InputManager.instance.SetCursorLock(true);
            new InventoryManager();

        }

        public void Update()
        {
            Character player = PlayerManager.Instance.GetPlayer().GetComponent<Character>();

            if (RadioIconWidget.Instance.isEnabled())
            {
                player.IAquireRadio();
            }
            EnemyManager.Instance.Update();
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

            if (InputManager.instance.Moved())
            {
                MapWidget.Instance.Enabled(false);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                MapWidget.Instance.Toggle();
            }

            if (InventoryManager.Instance.HasItem("Radio"))
            {
                RadioIconWidget.Instance.Enabled(true);
            }
            else
            {
                RadioIconWidget.Instance.Enabled(false);
            }


            InputManager.instance.Update();
        }
    }
}