using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight_Energy_UI : MonoBehaviour {
	public PlayerScript playerScript;
	public LayoutElement Bar;

	// Use this for initialization
	void Start() {	}
	
	// Update is called once per frame
	void Update () {
		Bar.minWidth = 256 * ( playerScript.light.CheckBatteryLevel() / 100);
	}
}
