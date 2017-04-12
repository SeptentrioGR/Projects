using UnityEngine;
public class Item_Spawn_Manager : MonoBehaviour
{

	public float spawnTime;
	public GameObject[] itemToSpawn;
	public Transform[] SpawnLocations;


	void Start()
	{
		SpawnRadio();
	}

	void Update()
	{

	}

	void SpawnRadio()
	{
		int RandomLocation = Random.Range(0, SpawnLocations.Length);
		Transform location = SpawnLocations[RandomLocation];
		GameObject radioPrefab = Instantiate(itemToSpawn[0], location.position, Quaternion.identity) as GameObject;
		radioPrefab.gameObject.name = itemToSpawn[0].name;
		radioPrefab.transform.SetParent(location);
	}
}
