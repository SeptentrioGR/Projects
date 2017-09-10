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
        public List<GameObject> m_ListOfEnemies = new List<GameObject>();

        public int maxNumberOfEnemies;
        public float TimePassSinceSpawn = 10;

        private int numberOfEnemies = 0;
        private int NumberOfEnemies;
        private int EnemyEachWave;



        public float mSpawnTime;
        public float SpawnRate;
        public float StartingTimer;
        public float Timer;

        float nextIncrease;
        float increaseRate = 1f;

        float nextIncreaseOfMonsters;
        float increaseOfMonstersRate;

        bool StartingIncreasingSpeed;
        bool SpawnEnemies;


        public void Enabled(bool value)
        {
            SpawnEnemies = value;
        }

        public void DeleteEnemies()
        {
            foreach (GameObject m in m_ListOfEnemies)
            {
                GameObject.Destroy(m);
            }
        }

        public void EnableSpawning(bool value)
        {
            SpawnEnemies = value;
        }

        public void Update()
        {
            if (SpawnEnemies)
            {
                if (m_ListOfEnemies.Count > 0)
                {
                    TimePassSinceSpawn -= Time.deltaTime;
                }
                
                if (TimePassSinceSpawn <= 0)
                {
                    DecreaseDistanceOfMonsters();
                    TimePassSinceSpawn = 10;
                }

                Spawn();

                if (StartingIncreasingSpeed)
                {
                    IncreaseSpeed(1);
                }

                if (Time.time > nextIncrease && maxNumberOfEnemies <= 4)
                {
                    nextIncrease = Time.time + increaseRate;
                    maxNumberOfEnemies++;
                }
            }
        }

        public void IncreaseEnemiesChaseSpeed()
        {
            if (!StartingIncreasingSpeed)
            {
                StartingIncreasingSpeed = !StartingIncreasingSpeed;
            }
        }



        public void IncreaseSpeed(int value)
        {
            if (Time.time > nextIncrease)
            {
                nextIncrease = Time.time + increaseRate;
                foreach (GameObject m in m_ListOfEnemies)
                {
                    m.GetComponentInChildren<MonsterAI>().speed += value;
                }
            }
            
        }

        public void DecreaseDistanceOfMonsters()
        {
            foreach (GameObject m in m_ListOfEnemies)
            {
                m.GetComponentInChildren<MonsterAI>().minDistanceToFollow--;
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
            m_ListOfEnemies.Add(en);
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

