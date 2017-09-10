using UnityEngine;
public class ItemManager
{
    private static ItemManager m_Instance;
    private GameObject[] m_Prefabs;
    private Transform[] m_SpawnLocations;
    private GameObject m_RadioInteractable;

    public static ItemManager Instance
    {
        get
        {
            return m_Instance;
        }
    }

    public GameObject GetRadio()
    {
        return m_RadioInteractable;
    }

    public ItemManager(GameObject[] itemToSpawn, Transform[] SpawnLocations)
    {
        m_Instance = this;
        this.m_Prefabs = itemToSpawn;
        this.m_SpawnLocations = SpawnLocations;
    }

    public void SpawnRadio()
	{
		int RandomLocation = Random.Range(0, m_SpawnLocations.Length);
		var location = m_SpawnLocations[RandomLocation];
        GameObject radioGO = GameObject.Instantiate(m_Prefabs[0], location.position, Quaternion.identity) as GameObject;
        radioGO.gameObject.name = m_Prefabs[0].name;
        radioGO.transform.SetParent(location);
        m_RadioInteractable = radioGO;

    }
}