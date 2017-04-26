using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Screens
{
	Game,Menu
}
[System.Serializable]
public class GameScreenManager{

	public Dictionary<Screens, GameObject> mScreens = new Dictionary<Screens, GameObject>();

	public void Initialise () {
		AddScreenByName(Screens.Menu, "MenuCanvas");
		AddScreenByName(Screens.Game, "GameCanvas");
	}
	
	public void AddScreenByName(Screens ele, string name)
	{
		GameObject go;
		if (!mScreens.TryGetValue(ele, out go))
		{
			go = GameObject.Find(name);
			mScreens.Add(ele, go);
		}
	}

	public void SetGameScreenManager(Screens ele)
	{
		foreach(Screens screen in mScreens.Keys)
		{
			mScreens[screen].SetActive(false);
		}
		mScreens[ele].SetActive(true);
	}
}
