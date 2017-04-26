using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun.Music
{
	public class Music : MonoBehaviour
	{
		public static Music Instance;
		private AudioSource MusicSource;
		public AudioClip[] Musics;
		// Use this for initialization
		void Start()
		{
			if (Instance != null)
			{
				Instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
			DontDestroyOnLoad(this);
		}

		// Update is called once per frame
		void Update()
		{
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
}
