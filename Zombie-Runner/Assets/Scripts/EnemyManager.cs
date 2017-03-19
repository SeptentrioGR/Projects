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
    public static Dictionary<string, EnemyManagerAction> actions = new Dictionary<string, EnemyManagerAction>();
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {

        spawnLocations = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            spawnLocations[i] = transform.GetChild(i);
        }
        EnemyHolder = transform;
        InvokeRepeating("SpawnEnemy", 2, 5);
        actions.Add("Score", OnEnemyDeath);
    }


    void Update()
    {
        numberOfEnemies = transform.GetChild(0).childCount;
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath();
        }
    }

    public void SpawnEnemy()
    {
        if (numberOfEnemies <= maxNumberOfEnemies)
        {
            GameObject en = Instantiate(enemies[0]) as GameObject;
            en.transform.position = spawnLocations[Random.Range(0, spawnLocations.Length)].position;
            transform.rotation = Quaternion.identity;
            en.transform.SetParent(transform.GetChild(0), false);
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

