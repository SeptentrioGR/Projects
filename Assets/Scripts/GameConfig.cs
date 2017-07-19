using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : MonoBehaviour {
    private static GameConfig m_Instance;
    public static GameConfig Instance
    {
        get
        {
            return m_Instance;
        }
    }

    [Header("ItemManager Config")]
    public float spawnTime;
    public GameObject[] itemToSpawn;
    public Transform[] SpawnLocations;

    public GameObject[] GetItemToSpawn()
    {
        return itemToSpawn;
    }

    public Transform[] GetItemSpawnLocations()
    {
        return SpawnLocations;
    }

    private void Awake()
    {
        m_Instance = this;
    }

    void Start () {
		
	}
	

	void Update () {
		
	}
}
