using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseChecked : MonoBehaviour {
	public string house_number;
	bool houseSearched;
	public Image ImageIconOnMap;
	// Use this for initialization
	void Start () {
		houseSearched = false;
		ImageIconOnMap = GameObject.Find("House" + house_number).GetComponent<Image>();
		ImageIconOnMap.GetComponent<Image>().color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
		if (houseSearched)
		{
			ImageIconOnMap.GetComponent<Image>().color = Color.red;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			houseSearched = true;
		}
	}


}
