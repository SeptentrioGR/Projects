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

        public void SetMusic(int index)
        {
            if (MusicSource.clip != Musics[index])
            {
                MusicSource.clip = Musics[index];
                MusicSource.Play();
            }
        }
		
	}
}
