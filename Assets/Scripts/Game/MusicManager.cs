using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun
{
	public class MusicManager : MonoBehaviour
	{
		private static MusicManager m_Instance;
        public static MusicManager Instance
        {
            get
            {
                return m_Instance;
            }
        }
        public AudioSource MusicSource;
        public AudioClip[] Musics;
        public AudioClip[] Sound;

        private void Awake()
        {
            m_Instance = this;
            MusicSource = GetComponent<AudioSource>();

        }
  
        public void PlaySound(int index)
        {
         
            if (MusicSource && !MusicSource.isPlaying && MusicSource.clip != Sound[index]){
                MusicSource.PlayOneShot(Sound[index]);
            }
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
