using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseChecked : MonoBehaviour {
    private string m_ID;
	public string house_number;
	bool houseSearched;
    
	void Start () {
        m_ID = "House" + house_number;
        houseSearched = false;
        MapWidget.Instance.SetImageColorByName(m_ID, Color.white);
	}

    public void Searched()
    {
   
    }

    public bool IsHouseSearched()
    {
        return houseSearched;
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
            if (!houseSearched)
            {
                MapWidget.Instance.SetImageColorByName("House" + house_number, Color.red);
                houseSearched = true;
            }
        }
	}


}
