using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieRun;

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

    public void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            PrefabManager.Instance.Map.SetActive(true);
        }

        if (Input.GetAxis("Vertical") > 0.5f || Input.GetAxis("Horizontal") > 0.5f || Input.GetAxis("Horizontal") < -0.5f || Input.GetAxis("Vertical") < -0.5f)
        {
           PrefabManager.Instance.Map.SetActive(false);
        }
    }

}
