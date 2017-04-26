using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
	public class EnemyManager : MonoBehaviour
	{
		public delegate void EnemyManagerAction();
		public EnemyManagerAction OnEnemyDeath;
		public static EnemyManager instance;
		private Transform EnemyHolder;
		public GameObject[] enemies;
		private Transform[] spawnLocations;
		public int maxNumberOfEnemies;
		private int numberOfEnemies = 0;
		private int NumberOfEnemies;
		private int EnemyEachWave;
		private int Wave;
		public float mSpawnTime;
		public float SpawnRate;
		public float StartingTimer;
		public float Timer;


		void Awake()
		{
			instance = this;

		}

		void Start()
		{

			spawnLocations = new Transform[transform.childCount];

			for (int i = 0; i < transform.childCount; i++)
			{
				spawnLocations[i] = transform.GetChild(i);
			}
			EnemyHolder = transform;

		}


		public void Spawn()
		{
				if (numberOfEnemies <= maxNumberOfEnemies)
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
			Transform spawnPos = spawnLocations[Random.Range(0, spawnLocations.Length)];
			GameObject en = Instantiate(enemies[0], spawnPos.position,Quaternion.identity) as GameObject;
			en.transform.SetParent(EnemyHolder, false);
			numberOfEnemies++;
		}

		public void SpawnEnemyButton()
		{
			GameObject en = Instantiate(enemies[0], spawnLocations[Random.Range(0, spawnLocations.Length)].position, Quaternion.identity) as GameObject;
			en.transform.SetParent(transform, false);
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

