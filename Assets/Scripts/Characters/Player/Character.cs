using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Water;
using System;
using System.Collections.Generic;
namespace ZombieRun
{

    public abstract class Character : MonoBehaviour
    {
        float m_Health;
        float m_Stamina;

        [Header("Stamina Thresholds")]
        [SerializeField]
        private float       m_DecreaseWhileWalk;
        [SerializeField]
        private float       m_DecreaseWhileRun;
        private bool        m_UnderWater;

        private Animator    m_Animator;
        public Vector3      m_StartingTransform;
        public Quaternion   m_StartingRotation;

        public Transform Hand;
        public float nextAttack;
        public float attackRate;
        public float damage;

        //----------------------------------------------------------------------------------------------------
        public bool UnderWater
        {
            get
            {
                return m_UnderWater;
            }
            set
            {
                m_UnderWater = value;
            }
        }

        //----------------------------------------------------------------------------------------------------
        public float RunningThreshold
        {
            get
            {
                return m_DecreaseWhileRun;
            }
        }

        //----------------------------------------------------------------------------------------------------
        public float WalkingThreshold
        {
            get
            {
                return m_DecreaseWhileWalk;
            }
        }

        //----------------------------------------------------------------------------------------------------
        public float Health
        {
            get
            {
                return m_Health;
            }
            set
            {
                m_Health = value;
            }
        }

        //----------------------------------------------------------------------------------------------------
        public float Stamina
        {
            get
            {
                return m_Stamina;
            }
            set
            {
                m_Stamina = value;
            }
        }

        //----------------------------------------------------------------------------------------------------
        void Start()
        {
            m_StartingTransform = transform.position;
            m_StartingRotation = Quaternion.identity;
        }

        //----------------------------------------------------------------------------------------------------
        public abstract void Death();

        //----------------------------------------------------------------------------------------------------
        public void HealthSystem()
        {
            if (m_UnderWater)
            {
                Health -= 1f;
            }

            if (Health <= 0.0f)
            {
                Death();
            }

            m_Health = Mathf.Clamp(Health, 0, 100);
        }

        //----------------------------------------------------------------------------------------------------
        public abstract void StaminaSystem();

        public void Attack(Character Target)
        {
            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackRate;
                Target.Damage(damage);
            }
        }

        //----------------------------------------------------------------------------------------------------
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Water>())
            {
                m_UnderWater = !m_UnderWater;
            }
        }

        //----------------------------------------------------------------------------------------------------
        public void Damage(float value)
        {
            m_Health -= value;
        }
    }

}