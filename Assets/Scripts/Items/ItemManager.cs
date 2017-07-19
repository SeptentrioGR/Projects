using UnityEngine;
public class ItemManager
{
    private static ItemManager m_Instance;

    public static ItemManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    private GameObject[] itemToSpawn;
    private Transform[] SpawnLocations;

    public ItemManager(GameObject[] itemToSpawn, Transform[] SpawnLocations)
    {
        m_Instance = this;
        this.itemToSpawn = itemToSpawn;
        this.SpawnLocations = SpawnLocations;
        SpawnRadio();
    }

    public void SpawnRadio()
	{
		int RandomLocation = Random.Range(0, SpawnLocations.Length);
		Transform location = SpawnLocations[RandomLocation];
		GameObject radioPrefab = GameObject.Instantiate(itemToSpawn[0], location.position, Quaternion.identity) as GameObject;
		radioPrefab.gameObject.name = itemToSpawn[0].name;
		radioPrefab.transform.SetParent(location);
	}
}
