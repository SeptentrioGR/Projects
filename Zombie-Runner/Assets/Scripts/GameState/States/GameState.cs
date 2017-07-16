using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class GameState : State
    {
        public GameState()
        {
            Debug.Log("Initialize GameState");
        }

        public void Initialize()
        {

        }

        public override void Start()
        {
            new PlayerManager();

            GameManager.Instance.ResetGame();
            EnemyManager.Instance.Initialize();
            new ItemManager(GameConfig.Instance.GetItemToSpawn(), GameConfig.Instance.GetItemSpawnLocations());
            new CountDown(60, 00, 1);
        }

        public override void Update()
        {
            Character player = PlayerManager.Instance.GetPlayer().GetComponent<Character>();

            UIManager.Instance.TogglePausePanel(GameManager.Instance.CheckIfPaused());


            if (RadioIconWidget.Instance.Enabled())
            {
                player.IAquireRadio();
            }

            EnemyManager.Instance.Spawn();

            RadioIconWidget.Instance.ChangeIconColor(Color.black);

            if (RadioClearArea.Instance.ClearArea)
            {
                RadioIconWidget.Instance.ChangeIconColor(Color.green);
            }

            PlayerStatusWidget.Instance.RefreshContent();

            if (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("Vertical") < -0.5f)
            {
                PrefabManager.Instance.m_Map.SetActive(false);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                Debug.Log("Pressed M");
                MapWidget.Instance.Toggle();
            }


        }
    }
}