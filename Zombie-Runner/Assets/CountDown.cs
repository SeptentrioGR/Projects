using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown : MonoBehaviour {
	public static CountDown Instance;
	public float m = 1f;
	public float s = 60f;
	private Text Clock;
	public bool StartCounting = false;
	// Use this for initialization
	void Start () {
		Instance = this;
		Clock = GetComponent<Text>();
	}

	public void Initialize()
	{

		StartCounting = true;
		UIManager.mInstance.Texts[UIManager.TextElements.Clock].enabled = true;
		UIManager.mInstance.Icons[UIManager.IconElements.Radio].enabled = false;
	}
	

	void Update () {
		Clock.text = string.Format("{0}:{1}", m, Mathf.Round(s));
		if (m > 0 && StartCounting)
		{
			s -= Time.deltaTime;
		
			if (s <= 0)
			{
				m--;
				s = 1;
			}
		} else
		{
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
