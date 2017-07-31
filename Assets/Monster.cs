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
        public float nextAttack;
        public float attackRate;

        public float damage;
        

        
        // Use this for initialization
        void Start()
        {
           
        }

        public void SetAttackPlayer(bool value)
        {
            AttackPlayer = value;
        }

        void Update()
        {

         

            if (AttackPlayer)
            {
                if (Time.time > nextAttack)
                {
                    nextAttack = Time.time + attackRate;
                    PlayerManager.Instance.GetPlayer().Damage(damage);
                }

                Rawr();
            }
      
         

        }
        
        //====================================================================================================
        public void TurnAndLookTarget()
        {
            //transform.RotateAround(transform.position, Vector3.up, ControlsManager.getAxisInput("Mouse X") * mouse_rotation_speed);
            //find the vector pointing from our position to the target
            var _direction = (PlayerManager.Instance.GetPlayer().transform.position - transform.position).normalized;

            //create the rotation we need to be in to look at the target
            var _lookRotation = Quaternion.LookRotation(_direction);
            _lookRotation.x = 0;
            _lookRotation.z = 0;
            //rotate us over time according to speed until we are in the required rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookRotation, RotationSpeed);
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
