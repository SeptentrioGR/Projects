
using System;
using UnityEngine;
[Serializable]
public class Flashlight
{

	public GameObject lightsource;
	public GameObject flashlightmodel;
	private float startingBattery;
	private float currentBattery;

	public void Initialize(float startingBattery)
	{
		this.startingBattery = startingBattery;
		currentBattery = startingBattery;
		flashlightmodel.SetActive(lightsource.GetComponent<Light>().enabled);
	}

	public void Update()
	{
		currentBattery -= Time.deltaTime;
		currentBattery = Mathf.Clamp(currentBattery, 0, startingBattery);
	}

	public void Power()
	{
		lightsource.GetComponent<Light>().enabled = !lightsource.GetComponent<Light>().enabled;
		flashlightmodel.SetActive(lightsource.GetComponent<Light>().enabled);
	}

	public void InsertBattery()
	{
		currentBattery = startingBattery;
	}

	public bool LightIsPowered()
	{
		return lightsource.GetComponent<Light>().enabled;
	}

}
