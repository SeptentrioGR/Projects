using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	private AudioSource MusicSource;
	public AudioClip[] Musics;
	// Use this for initialization
	void Start () {
		MusicSource = GameObject.Find("World").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		switch (GameManager.Instance.gameState)
		{
			case GameStates.Menu:
				if (MusicSource.clip != Musics[0])
				{
					MusicSource.clip = Musics[0];
					MusicSource.Play();
				}
				break;
			case GameStates.Game:
				if (MusicSource.clip != Musics[1])
				{
					MusicSource.clip = Musics[1];
					MusicSource.Play();
				}
				break;
		}
	}


}
