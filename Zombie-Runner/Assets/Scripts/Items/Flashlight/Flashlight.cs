
using System;
using UnityEngine;
[Serializable]
public class Flashlight
{

	public GameObject lightsource;
	public float FlashlightBatteryThreshold;
	public float startingBattery = 100;
	public float currentBattery;

	public void Initialize(float startingBattery)
	{
		this.startingBattery = startingBattery;
		currentBattery = startingBattery;
	}

	public void Update()
	{

		if (currentBattery <= 0)
		{
			currentBattery = 0;
			if (LightIsPowered())
			{
				Power();
			}
		}


		if (LightIsPowered())
		{
			currentBattery -= FlashlightBatteryThreshold * Time.deltaTime;
		}
		else
		{
			currentBattery += FlashlightBatteryThreshold * Time.deltaTime;
		}
		currentBattery = Mathf.Clamp(currentBattery, 0, startingBattery);
	}

	public void Power()
	{
		lightsource.GetComponent<Light>().enabled = !lightsource.GetComponent<Light>().enabled;
	}

	public void InsertBattery()
	{
		currentBattery = startingBattery;
	}

	public bool LightIsPowered()
	{
		return lightsource.GetComponent<Light>().enabled;
	}

	public float CheckBatteryLevel()
	{
		return currentBattery;
	}

}
