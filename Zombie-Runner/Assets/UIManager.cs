using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager{
	private static UIManager instance = new UIManager();
	public Dictionary<string, Image> Icons = new Dictionary<string, Image>();
	private Image RadioIcon;

	public static UIManager Instance
	{
		get
		{
			return instance;
		}
	}

	public void Initialize()
	{
		RadioIcon = GameObject.Find("RadioIcon").GetComponent<Image>();
		Icons.Add("Radio", RadioIcon);
		RadioIcon.gameObject.SetActive(false);
	}


	public void AddIconDictionary(string name,Image icon)
	{
		Icons.Add(name, icon);
	}

	public Image GetIcon(string name)
	{
		Image ImageIcon;
		if (Icons.TryGetValue(name, out ImageIcon))
		{
			return ImageIcon;
		}
		return null;
	}
}
