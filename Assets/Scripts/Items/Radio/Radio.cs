using System;
using UnityEngine;
namespace ZombieRun
{
    public class Radio : MonoBehaviour
    {
        private bool used;
        private Helicopter Helicopter;
        public GameObject LandingPrefab;

        void Start()
        {
            try
            {
                Helicopter = PrefabManager.Instance.m_RescueHelicopter;
            }
            catch
            {
                Debug.LogWarning("Rescue Helicopter does not exist");
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.E) && RadioClearArea.Instance.ClearArea && !used)
            {
                Use();
            }
        }
 
        public void Use()
        {
            Action();
        }

        public void Action()
        {
            Character Player = PlayerManager.Instance.GetPlayer();
            used = true;
            GameObject go = Instantiate(LandingPrefab,
                Player.transform.position, Player.transform.rotation) as GameObject;
            go.name = LandingPrefab.name;
            Helicopter.CalLHelp();
            gameObject.SetActive(false);
        }
    }
}
