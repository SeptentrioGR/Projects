using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager {
	public static InputManager instance = new InputManager();

	public InputManager(){}

	public static InputManager Instance
	{
		get
		{
			return instance;
		}
	}


	public bool PauseKeyIsPressed()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			Debug.Log("Pressed Key For Paused");
			return true;
		}
		return false;
	}

}
