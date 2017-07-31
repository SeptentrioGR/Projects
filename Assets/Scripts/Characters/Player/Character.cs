using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Water;
using System;
using System.Collections.Generic;
namespace ZombieRun
{

    public abstract class Character : MonoBehaviour
    {
        public float mHealth = 100;
        public float mStamina = 100;

        [Header("Stamina Thresholds")]
        public float decreaseWhileWalk;
        public float decreaseWhileRun;
        public bool UnderWater;
        private Animator mAnimation;

        public Vector3 StartingTransform;
        public Quaternion StartingRotation;

        public Transform Hand;



        void Start()
        {
            StartingTransform = transform.position;
            StartingRotation = Quaternion.identity;
        }


        // Update is called once per frame
        void Update()
        {
            HealthSystem();
            StaminaSystem();
        }

        public abstract void Death();

        void HealthSystem()
        {
            if (UnderWater)
            {
                mHealth -= 1f;
            }
            if (mHealth <= 0.0f)
            {
                Death();
            }
            mHealth = Mathf.Clamp(mHealth, 0, 100);
        }

        public abstract void StaminaSystem();

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Water>())
            {
                UnderWater = !UnderWater;
            }
        }

        public void Damage(float value)
        {
            mHealth -= value;
        }
    }

}