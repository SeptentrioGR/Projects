using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace ZombieRun
{

    public enum Actions
    {
        Idle, Walking, Searching, Attacking, Hit, Dead
    }

    [RequireComponent(typeof(NavMeshAgent))]
    public class MonsterAI : Interactable
    {

        private NavMeshAgent agent;
        public float speed;
        public float minDistanceToAttack = 4;
        public float minDistanceToFollow;
        [SerializeField]
        public Actions curAction;
        public float distance;

        public float TimeTillEatPlayer;
        private Monster mMonster;
        private IsVisibleOrNot mVisibleByCameraScript;
        private bool mVisibleByCamera;
        public Vector3 m_LastKnownLocation;
        private bool m_HittingTheEnemy = false;


        public bool HittingTheEnemy
        {
            get
            {
                return m_HittingTheEnemy;
            }
            set
            {
                m_HittingTheEnemy = value;
            }
        }

        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            curAction = Actions.Walking;
            agent.stoppingDistance = minDistanceToFollow;
            mMonster = GetComponent<Monster>();
            mVisibleByCameraScript = GetComponentInChildren<IsVisibleOrNot>();
            agent.speed = UnityEngine.Random.Range(4, 6);
        }

        void Update()
        {
            if (PlayerManager.Instance == null)
            {
                return;
            }

            Player player = PlayerManager.Instance.GetPlayer().GetComponent<Player>();

            if (HittingTheEnemy)
            {
                HittingTheEnemy = false;
            }

            agent.speed = Mathf.Clamp(speed, 1, 6);

            mVisibleByCamera = mVisibleByCameraScript.IsVisibleByPlayer;

            distance = Vector3.Distance(player.transform.position, transform.position);
            mMonster.FaceTarget();


            if (distance < radius && curAction != Actions.Walking)
            {
                curAction = Actions.Walking;
            }

            if (distance <= minDistanceToAttack && curAction != Actions.Attacking)
            {
                curAction = Actions.Attacking;
            }

            if (curAction != Actions.Idle && HittingTheEnemy && mVisibleByCamera && player.m_Flashlight.LightIsPowered())
            {
                curAction = Actions.Idle;
            }

            switch (curAction)
            {
                case Actions.Idle:
                    Idle();
                    break;
                case Actions.Walking:
                    Chase();
                    break;
                case Actions.Searching:
                    break;
                case Actions.Attacking:
                    Attack();
                    break;
                case Actions.Hit:
                    break;
                case Actions.Dead:
                    break;
                default:
                    break;
            }
        }

        void Idle()
        {
            agent.SetDestination(transform.position);
        }


        void Searching()
        {
            agent.SetDestination(m_LastKnownLocation);
        }

        void Chase()
        {
            mMonster.SetAttackPlayer(false);
            m_LastKnownLocation = PlayerManager.Instance.GetPlayer().transform.position;
            agent.SetDestination(m_LastKnownLocation);

        }

        void Attack()
        {
            agent.SetDestination(transform.position);
            TimeTillEatPlayer += .1f * Time.deltaTime;
            mMonster.SetAttackPlayer(true);
        }

        public override void OnInteraction()
        {
            Debug.Log("Interacting to : " + gameObject.name);
        }

        public override void CloseTo()
        {
            Debug.Log("Close to : " + gameObject.name);
            HittingTheEnemy = true;
            Game.Instance.HittingTheEnemy = true;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, m_LastKnownLocation);

            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(m_LastKnownLocation, 1.0f);
        }



    }
}
