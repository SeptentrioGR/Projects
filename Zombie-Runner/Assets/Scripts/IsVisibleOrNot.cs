using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisibleOrNot : MonoBehaviour {

	public GameObject en;
	public bool IsVisibleByPlayer;

	void OnBecameInvisible()
	{
		Debug.Log("Is InVisible");
		IsVisibleByPlayer =  false;
	}

	void OnBecameVisible()
	{
		Debug.Log("Is Visible");
		IsVisibleByPlayer = true;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
