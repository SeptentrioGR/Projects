using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour {
	public static CountDown Instance;
	public float m = 1f;
	public float startingSeconds = 60f;
	public float s;
	private Text Clock;
	public bool StartCounting = false;
	public float speed;
	// Use this for initialization
	void Start () {
		Instance = this;
		Clock = GetComponent<Text>();
		s = startingSeconds;
	}

	public void Initialize()
	{
		StartCounting = true;
		UIManager.mInstance.Texts[UIManager.TextElements.Clock].enabled = true;
		UIManager.mInstance.Icons[UIManager.IconElements.Radio].enabled = false;
	}
	

	void Update () {
		Clock.text = string.Format("{0}:{1}", m.ToString("00"), Mathf.Round(s).ToString("00"));
		if (m > 0 && StartCounting)
		{
			s -= Time.deltaTime * speed;	
			if (s <= 0)
			{
				m--;
				s = startingSeconds;
			}
		} else if(StartCounting)
		{
			s = 0;
			StartCounting = false;
		}
	}

	public bool TimeIsUp()
	{
		if(m <= 0)
		{
			return true;
		}
		return false;
	}
}
