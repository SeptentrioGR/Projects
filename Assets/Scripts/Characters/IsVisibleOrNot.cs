using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisibleOrNot : MonoBehaviour {

	public GameObject en;
	public bool IsVisibleByPlayer;

	void OnBecameInvisible()
	{
		IsVisibleByPlayer =  false;
	}

	void OnBecameVisible()
	{
		IsVisibleByPlayer = true;
	}

}
