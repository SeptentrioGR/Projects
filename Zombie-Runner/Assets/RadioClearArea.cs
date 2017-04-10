using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioClearArea : MonoBehaviour {
	public static RadioClearArea Instance;
	private GameObject player;
	public bool ClearArea;
	public float timeSinceLastTrigger = 0f;

	void Start () {
		player = GameObject.Find("Player");
		Instance = this;

	}
	

	void Update () {
		transform.position = player.transform.position;
		timeSinceLastTrigger += Time.deltaTime;

		if (ClearArea)
		{
			Debug.Log("Clear Area");
		}
	}

	private bool foundClearArea = false;



	void OnTriggerStay(Collider collider)
	{
		if (collider.tag != "Player")
		{
			timeSinceLastTrigger = 0f;
			ClearArea = false;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag != "Player")
		{
			ClearArea = true;
		}
	}


}
