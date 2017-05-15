using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public bool FirstRun = true;
	public static UIManager mInstance = new UIManager();
	public GameObject UICanvas;


	public enum IconElements
	{
		Radio
	}

	public enum PanelElements
	{
		Pause,
		Winning
	}

	public enum TextElements
	{
		Clock
	}

	public Dictionary<IconElements, Image> Icons = new Dictionary<IconElements, Image>();
	public Dictionary<PanelElements, GameObject> Panels = new Dictionary<PanelElements, GameObject>();
	public Dictionary<TextElements, Text> Texts = new Dictionary<TextElements, Text>();

	public void Awake()
	{
		mInstance = this;
		Initialize();
	}

	public void Initialize()
	{
		UICanvas = GameObject.Find("GameCanvas");
		AddIcon(IconElements.Radio, "RadioIcon");
		AddPanel(PanelElements.Pause, "PausePanel");
		AddPanel(PanelElements.Winning, "WinPanel");
		AddTextElementByName(TextElements.Clock, "ClockTimer");
		Icons[IconElements.Radio].enabled = false;
		Texts[TextElements.Clock].enabled = false;
		Panels[PanelElements.Pause].SetActive(false);
		Panels[PanelElements.Winning].SetActive(false);
	}


	public void AddIcon(IconElements name,string icon)
	{
		Image imageIcon;
		if (!Icons.TryGetValue(name, out imageIcon))
		{
			imageIcon = GameObject.Find(icon).GetComponent<Image>();
			Icons.Add(name, imageIcon);
		}
	}

	public void AddTextElementByName(TextElements ele, string name)
	{
		Text text;
		if (!Texts.TryGetValue(ele, out text))
		{
			text = GameObject.Find(name).GetComponent<Text>();
			Texts.Add(ele, text);
		}
	}

	public void AddPanel(PanelElements ele, string name)
	{
		GameObject panelGameObject;
		if (!Panels.TryGetValue(ele, out panelGameObject))
		{
			panelGameObject = UICanvas.transform.Find(name).gameObject;
			Panels.Add(ele, panelGameObject);
		}
	}


	public Image GetIcon(IconElements name)
	{
		Image ImageIcon;
		if (Icons.TryGetValue(name, out ImageIcon))
		{
			return ImageIcon;
		}
		return null;
	}


	public void ChangeIconColor(Color color)
	{
		Icons[IconElements.Radio].color = color;
	}
}
