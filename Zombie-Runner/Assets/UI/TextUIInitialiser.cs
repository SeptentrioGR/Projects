using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUIInitialiser {

	public Dictionary<string, Button> buttons = new Dictionary<string, Button>();
	public Dictionary<string, Text> GUILabels = new Dictionary<string, Text>();
	
	public void Initialise() {
		buttons.Add("Play", GameObject.Find("Play").GetComponent<Button>());
		buttons.Add("Options", GameObject.Find("Options").GetComponent<Button>());
		buttons.Add("Exit", GameObject.Find("Exit").GetComponent<Button>());


		GUILabels.Add("Title", GameObject.Find("Title").GetComponent<Text>());

	}

	public void setText(string id,string text)
	{
		GUILabels[id].text = text;
	}


		

	void Update () {
		
	}
}
