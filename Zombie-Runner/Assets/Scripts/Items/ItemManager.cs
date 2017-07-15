using UnityEngine;
public class ItemManager : MonoBehaviour
{
    private static ItemManager m_Instance;
    public static ItemManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public float spawnTime;
	public GameObject[] itemToSpawn;
	public Transform[] SpawnLocations;

    private void Awake()
    {
        m_Instance = this;
    }

    public void Initialize()
    {
        SpawnRadio();
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
