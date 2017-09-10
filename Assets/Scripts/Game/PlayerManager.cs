using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRun;

namespace ZombieRun
{

    public class PlayerManager
    {
        private static PlayerManager m_Instance;
        private Player Player;

        public PlayerManager()
        {
            Debug.Log("Player Initialization");
            m_Instance = this;
            Player = PrefabManager.Instance.m_Player;
        }

        public static PlayerManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public Character GetPlayer()
        {
            if (Player)
            {
                return Player;
            }
            return null;
        }
    }
}
