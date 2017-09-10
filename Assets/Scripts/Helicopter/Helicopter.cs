using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class Helicopter : Interactable
    {
        private static Helicopter m_Instance;

        private Animator m_Animator;
        public Vector3 m_Destination;
        public bool m_Called;
        public float m_Speed = 100f;
        public Vector3 m_Offset;
        public float m_Distance;

        public static Helicopter Instance
        {
            get
            {
                return m_Instance;
            }
        }

        private void Awake()
        {
            m_Instance = this;
        }

        void Start()
        {
            m_Animator = GetComponentInChildren<Animator>();
            m_Animator.enabled = false;
        }


        void Update()
        {
            m_Distance = (transform.position - (m_Destination + m_Offset)).magnitude;

            if (m_Distance < 0.5f)
            {
                if (!m_Animator.enabled)
                {
                    m_Animator.enabled = true;
                }
            }
            if (m_Destination != Vector3.zero && m_Called)
            {
                Vector3 lookDirection = m_Destination + m_Offset;
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.position = Vector3.Lerp(transform.position, lookDirection, m_Speed * Time.deltaTime);
            }
        }

        public void CallHelipter()
        {
            if (!m_Called)
            {
                MusicManager.Instance.SetMusic(2);
                m_Called = true;
                NarationManager.Instance.Signal();
                NarationManager.Instance.StartNaration();
            }

        }

        public void GoToArea()
        {
            m_Destination = GameObject.Find("LandingArea").gameObject.transform.position;
        }

        public void Silence()
        {
            GetComponentInChildren<AudioSource>().Stop();
        }

        public override void OnInteraction()
        {
            GameManager.Instance.GameOver();
        }

        public override void CloseTo()
        {
  
        }
    }
}
