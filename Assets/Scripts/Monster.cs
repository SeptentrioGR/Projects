using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ZombieRun
{
    public class Monster : Character
    {
        public Rigidbody mRigidBody;
        private float RotationSpeed = 25f;
        public AudioClip[] sounds;
        public float RawrFrequence;
        public float timer;

        public bool AttackPlayer = false;




        // Use this for initialization
        void Start()
        {
            Health = 100;
            Stamina = 100;
            damage = 5;
            attackRate = 0.3f;
        }

        public void SetAttackPlayer(bool value)
        {
            AttackPlayer = value;
        }

        void Update()
        {
            HealthSystem();
            StaminaSystem();

            if (AttackPlayer)
            {
                Attack(PlayerManager.Instance.GetPlayer());
                Rawr();
            }

        }

        //====================================================================================================
        public void FaceTarget()
        {
            //transform.RotateAround(transform.position, Vector3.up, ControlsManager.getAxisInput("Mouse X") * mouse_rotation_speed);
            //find the vector pointing from our position to the target
            var direction = (PlayerManager.Instance.GetPlayer().transform.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            var looRotation = Quaternion.LookRotation(new Vector3(direction.x,0, direction.z));
 
            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, looRotation, Time.deltaTime * RotationSpeed);
        }

        public void Rawr()
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                timer = RawrFrequence;
                GetComponent<AudioSource>().clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
                GetComponent<AudioSource>().Play();
            }
        }

        public override void Death()
        {
            Destroy(gameObject);
        }

        public override void StaminaSystem()
        {
            //Placeholder
        }
    }
}
