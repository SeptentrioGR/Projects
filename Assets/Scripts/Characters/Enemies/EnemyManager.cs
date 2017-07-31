using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun
{
    [Serializable]
    public class EnemyManager
    {
        public delegate void EnemyManagerAction();
        public EnemyManagerAction OnEnemyDeath;

        private static EnemyManager m_Instance;
        public static EnemyManager Instance
        {
            get
            {
                return m_Instance;
            }
        }

        private Transform EnemyHolder;

        public GameObject[] enemies;
        public Transform[] spawnLocations;
        public Queue<GameObject> m_ListOfEnemies = new Queue<GameObject>();

        public int maxNumberOfEnemies;
        public float TimePassSinceSpawn = 10;

        private int numberOfEnemies = 0;
        private int NumberOfEnemies;
        private int EnemyEachWave;
        private int Wave;


        public float mSpawnTime;
        public float SpawnRate;
        public float StartingTimer;
        public float Timer;

        public void Update()
        {
            if (m_ListOfEnemies.Count > 0)
            {
                TimePassSinceSpawn -= Time.deltaTime;
            }
            if (TimePassSinceSpawn <=0)
            {
                maxNumberOfEnemies++;
                DecreaseDistanceOfMonsters();
                TimePassSinceSpawn = 10;
            }

            Spawn();

           
        }

        public void DecreaseDistanceOfMonsters()
        {
            foreach (GameObject m in m_ListOfEnemies)
            {
                m.GetComponent<MonsterAI>().minDistanceToFollow--;
            }
        }
        public void Initialize()
        {
            m_Instance = this;
            GameObject eh = new GameObject("EnemyHolder");
            EnemyHolder = eh.transform;
            Timer = StartingTimer;
        }


        public void Spawn()
        {
          
            if (numberOfEnemies < maxNumberOfEnemies && maxNumberOfEnemies > 0)
            {
                Timer -= Time.deltaTime;
            }

            if (Timer <= 0)
            {
                Timer = StartingTimer;
                SpawnEnemy();
            }

            if (OnEnemyDeath != null)
            {
                OnEnemyDeath();
            }
        }




        public void SpawnEnemy()
        {
            Transform spawnPos = spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Length)];
            GameObject en = GameObject.Instantiate(enemies[0], spawnPos.position, Quaternion.identity) as GameObject;
            en.transform.SetParent(EnemyHolder, false);
            numberOfEnemies++;
        }

        public void IncreaseWave()
        {
            Wave++;
        }

        public void setEnemyEachWave()
        {
            EnemyEachWave += 10;
        }

        public void IncreaseNumberOfEnemies()
        {
            NumberOfEnemies++;
        }

    }
}

