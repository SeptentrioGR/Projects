using System;
using UnityEngine;
public class Radio : MonoBehaviour,Item
{
	public bool used;
	public Helicopter Helicopter;
	public GameObject LandingPrefab;
	void Start()
	{
		Helicopter = GameObject.Find("Rescure_Helicopter").GetComponent<Helicopter>();
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.E) && RadioClearArea.Instance.ClearArea && !used)
		{
			Use();
		}
	}



	public void Use()
	{
		Action();
	
	}

	public void Action()
	{
		used = true;
		Debug.Log("Using the radio");
		GameObject go = Instantiate(LandingPrefab, GameObject.FindGameObjectWithTag("Player").transform.position, GameObject.FindGameObjectWithTag("Player").transform.rotation) as GameObject;
		go.name = LandingPrefab.name;
		Helicopter.CalLHelp();
	
	}
}
