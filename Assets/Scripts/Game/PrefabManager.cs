using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZombieRun
{
    public class PrefabManager : MonoBehaviour
    {
        private static PrefabManager m_Instance;

        public static PrefabManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        public GameObject[] m_ListOfPrefabs;

        public Player m_Player;
        public EnemyManager m_EnemyManager;
        public GameObject   m_Map;
        public Text Clock;

        public Helicopter m_RescueHelicopter;


        public GameObject GetItemInList(string id)
        {
            foreach (GameObject go in m_ListOfPrefabs)
            {
                if (go.name.Equals(id))
                {
                    return go;
                }
            }
            return null;
        }

        void Awake()
        {
            m_Instance = this;
        }
    }
}
