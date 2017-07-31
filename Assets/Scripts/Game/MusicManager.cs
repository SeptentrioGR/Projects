using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZombieRun
{
	public class MusicManager : MonoBehaviour
	{
		private static MusicManager mInstance;
        public static MusicManager Instance
        {
            get
            {
                return mInstance;
            }
        }

        private AudioSource MusicSource;
		public AudioClip[] Musics;
        public AudioClip[] Sound;

        private void Awake()
        {
            mInstance = this;
        }
        // Use this for initialization
        void Start()
		{
            if (mInstance == null)
            {
                mInstance = this;
            }
            else { 
                Destroy(gameObject);
			}
            if (PlayerManager.Instance != null)
            {
                MusicSource = PlayerManager.Instance.GetPlayer().GetComponent<AudioSource>();
            }
            else
            {
                MusicSource = Camera.main.GetComponent<AudioSource>();
            }
           


            DontDestroyOnLoad(this);
		}

        public void PlaySound(int index)
        {
            if(!MusicSource.isPlaying && MusicSource.clip != Sound[index]){
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
