using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.RainMaker;
public class Thunder : MonoBehaviour {

	public static Thunder Instance;

	public RainScript mainRainScript;
	public AudioSource[] RainAudio;
	public Animator LightingAnimator;
	public bool Thundering;
	// Use this for initialization
	void Start () {
		Instance = this;
		RainAudio = GetComponents<AudioSource>();
		mainRainScript = GetComponent<RainScript>();
		
	}
	
	public void PlayThunder()
	{
			LightingAnimator.SetTrigger("Thunder");
	}

	// Update is called once per frame
	void Update () {

		if (RainAudio.Length <= 0)
		{
			RainAudio = GetComponents<AudioSource>();
		}

		foreach (AudioSource Asource in RainAudio)
		{
			if (Asource.isPlaying)
			{
				Debug.Log(Asource.time);
				if(Asource.time > 20.0f && !Thundering)
				{
					Thundering = true;
					PlayThunder();
				}
			}
		}
	}
}
