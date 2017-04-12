using System.Collections.Generic;
using UnityEngine;

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


	void Update()
	{
		if (GameManager.Instance.gameState == GameStates.Game)
		{
			numberOfEnemies = transform.GetChild(0).childCount;
			Timer -= Time.deltaTime;
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
	}

	public void SpawnEnemy()
	{
		if (numberOfEnemies <= maxNumberOfEnemies)
		{
			GameObject en = Instantiate(enemies[0]) as GameObject;
			en.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length)].position;
			transform.rotation = Quaternion.identity;
			en.transform.SetParent(EnemyHolder, false);
		}
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

