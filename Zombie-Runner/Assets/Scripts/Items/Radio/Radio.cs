using System;
using UnityEngine;
public class Radio : MonoBehaviour
{
	private bool used;
	private Helicopter Helicopter;
	public GameObject LandingPrefab;
	void Start()
	{
		try
		{
			Helicopter = GameObject.Find("Rescue_Helicopter").GetComponent<Helicopter>();
		}
		catch
		{
			Debug.LogWarning("Rescue Helicopter does not exist");
		}
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
		gameObject.SetActive(false);
	
	}
}
